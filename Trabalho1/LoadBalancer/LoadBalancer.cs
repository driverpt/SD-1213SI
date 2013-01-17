using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Messaging;
using System.Threading;
using Contracts;

namespace LoadBalancer
{
    public class LoadBalancer : MarshalByRefObject, ILoadBalancer
    {
        // Maximum number of consecutive failures per executor before unregistering it
        private const int MaxAttempts = 3;

        private static readonly ConcurrentDictionary<int, IJob> JobList;
        private static readonly ConcurrentDictionary<string, ExecutorInfo> Executors;
        
        // Keeps track of which Executor was used to execute a job
        private static readonly ConcurrentDictionary<int, ExecutorInfo> JobExecutorMapper;

        // Used to generate an id for a new job
        private static int _jobIdGenerator;

        // Used in round-robin scheduling alogrithm
        private static int _orderNumber;

        // Async calls to Executor
        private delegate bool JobExecutor(string execFileName, string arguments);

        /// <summary>
        /// Aggregates information about an Executor. 
        /// </summary>
        private class ExecutorInfo
        {
            // number of consecutive failures
            private int _failures;

            /// <summary>
            /// Creates a new ExecutorInfo, using the specified URI. 
            /// </summary>
            /// <param name="uri">The Executor URI.</param>
            public ExecutorInfo(string uri) { Uri = uri; }

            public override string ToString() { return Uri; }
            
            /// <summary>
            /// Signals a connection failure and returns the current connection attempts count.
            /// </summary>
            /// <returns>Current consecutive failures count.</returns>
            public int Failed() { return Interlocked.Increment(ref _failures); }
            
            /// <summary>
            /// Signals a successfull connection attempt, resetting the count back to zero.
            /// </summary>
            public void Ok() { _failures = 0; }
            
            /// <summary>
            /// Gets the Executor URI.
            /// </summary>
            public string Uri { get; private set; }

            /// <summary>
            /// Gets the Executor consecutive failures count.
            /// </summary>
            public int Failures   { get { return _failures; } }
        }

        static LoadBalancer()
        {
            JobList = new ConcurrentDictionary<int, IJob>();
            Executors = new ConcurrentDictionary<string, ExecutorInfo>();
            JobExecutorMapper = new ConcurrentDictionary<int, ExecutorInfo>();
        }

        public override object InitializeLifetimeService()
        {
            return null;
        }

        public void RegisterExecutor(string executorUri)
        {
            Executors.GetOrAdd(executorUri, new ExecutorInfo(executorUri));
            Console.WriteLine("New Executor has been registered: {0}", executorUri);
        }

        public void UnregisterExecutor(string executorUri)
        {
            ExecutorInfo executorInfo;
            Executors.TryRemove(executorUri, out executorInfo);
            Console.WriteLine("Executor has been unregistered: {0}", executorUri);
        }

        public JobStatus GetJobStatus(int jobId)
        {
            IJob job;
            JobList.TryGetValue(jobId, out job);
            if (job != null)
            {
                Console.WriteLine("Status of job {0} requested: {1}", jobId, job.Status);
                return job.Status;
            }

            Console.WriteLine("Job {0} not found, unknown status", jobId);
            throw new KeyNotFoundException(String.Format("Job {0} not found, unknown status", jobId));
        }

        /// <summary>
        /// Creates and dispatches a new job to an executor.
        /// </summary>
        public IJob ExecuteJob(string executable, string arguments)
        {
            IJob job = CreateJob(executable, arguments);
            ExecuteJob(job);

            Console.WriteLine("Jobs Scheduled: {0}", JobList.Count);
            return job;
        }

        /// <summary>
        /// Dispatches a job to an executor.
        /// </summary>
        private void ExecuteJob(IJob job)
        {
            ExecutorInfo executorInfo = null;
            IExecutor executor;

            try
            {
                executor = GetNextExecutor(out executorInfo);
            }
            catch (Exception ex)
            {
                if (ex is NoExecutorsAvailableException)
                    throw;

                if (executorInfo != null)
                {
                    Console.WriteLine("Error accessing executor {0}: {1}.", executorInfo, ex.Message);
                    UnregisterExecutor(executorInfo.Uri);
                    Console.WriteLine("Trying again with another executor.");
                }
                
                ExecuteJob(job);
                return;
            }

            job.Status = JobStatus.Executing;

            JobExecutorMapper.TryAdd(job.Id, executorInfo);

            JobExecutor jobExecutor = executor.ExecuteJob;
            jobExecutor.BeginInvoke(job.Executable, job.Arguments, OnJobExecutedCallback, job);
        }

        /// <summary>
        /// Callback for executor async call.
        /// </summary>
        /// <param name="ar"></param>
        private void OnJobExecutedCallback(IAsyncResult ar)
        {
            // Get delegate that initiated the async call
            var caller = (JobExecutor) ((AsyncResult)ar).AsyncDelegate;

            // Get the job that was sent to the executor
            var job = (IJob) ar.AsyncState;

            ExecutorInfo executorInfo;
            JobExecutorMapper.TryGetValue(job.Id, out executorInfo);

            try
            {
                bool jobResult = caller.EndInvoke(ar);

                job.Status = (jobResult) ? JobStatus.Completed : JobStatus.Failed;
                
                Console.WriteLine("Job {0} complete. Result: {1}", job.Id, job.Status);
                executorInfo.Ok();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error while executing job {0}: {1}.", job.Id, ex.Message);

                int attempts = executorInfo.Failed();
                if (attempts >= MaxAttempts)
                {
                    Console.WriteLine("Executor failed too many times, unregistering executor...");
                    UnregisterExecutor(executorInfo.Uri);
                }

                Console.WriteLine("Trying again with a different executor.");
                
                try
                {
                    ExecuteJob(job);                    
                }
                catch (NoExecutorsAvailableException)
                {
                    job.Status = JobStatus.Failed;
                }
                
            }
        }

        /// <summary>
        /// Creates a new job.
        /// </summary>
        private IJob CreateJob(string executable, string arguments)
        {
            IJob job = new Job(executable, arguments);

            job.Id = Interlocked.Increment(ref _jobIdGenerator);
            JobList.TryAdd(job.Id, job);

            Console.WriteLine("New request arrived. Id: {0}", job.Id);
            job.Status = JobStatus.Executing;

            return job;
        }

        /// <summary>
        /// Gets a proxy to the next executor, using round-robin scheduling.
        /// </summary>
        /// <param name="executorInfo">[out] executorInfo of the next executor.</param>
        /// <returns>Next executor to use.</returns>
        /// <exception cref="NoExecutorsAvailableException"/>
        /// <exception cref="RemotingException" />
        private static IExecutor GetNextExecutor(out ExecutorInfo executorInfo)
        {
            // Get a snapshot of the current list of Executors
            var snapshot = Executors.ToArray(); // Thread-safe
            if (snapshot.Length == 0)
                    throw new NoExecutorsAvailableException();

            int order = Interlocked.Increment(ref _orderNumber);

            executorInfo = snapshot[order % snapshot.Length].Value;

            var executor = (IExecutor)Activator.GetObject(typeof(IExecutor), executorInfo.Uri);
            Debug.Assert(RemotingServices.IsTransparentProxy(executor));

            return executor;
        }
    }

    
}
