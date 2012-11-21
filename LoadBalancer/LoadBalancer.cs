using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contracts;

namespace TrabalhoPratico1
{
    public class LoadBalancer : MarshalByRefObject, ILoadBalancer
    {
        private static readonly List<IJob> JobList = new List<IJob>();

        private static readonly List<string> Executors = new List<string>();

        private static volatile int _orderNumber = 0;

        public void RegisterExecutor(string executorUri)
        {
            Console.WriteLine("New Executor has arrived");
            Executors.Add(executorUri);
            Console.WriteLine("New Executor has been registered: {0}", executorUri);
        }

        public void UnregisterExecutor(string executorUri)
        {
            Executors.Remove(executorUri);
        }

        public IJob ExecuteJob(string executable, string arguments, Action callback=null)
        {
            Console.WriteLine("New Request Arrived");
            var job = new Job(executable, arguments, callback);

            JobList.Add(job);
            string executorUri = Executors[_orderNumber % Executors.Count];

            IExecutor executor = (IExecutor) Activator.GetObject(typeof (IExecutor), executorUri);

            Func<string, string, string> del = executor.ExecuteJob;
            job.Status = JobStatus.Executing;
            del.BeginInvoke(job.Executable, job.Arguments, (result) =>
            {
                string jobResult = del.EndInvoke(result);
                job.Status = (jobResult == JobStatus.Success.ToString()) ? JobStatus.Success : JobStatus.Failed;
                if (job.Callback != null)
                {
                    job.Callback();
                }
            }, null);
            Console.WriteLine("Jobs Scheduled: {0}", JobList.Count);
            return job;
        }
    }
}
