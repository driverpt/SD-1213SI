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

        private static readonly List<IExecutor> Executors = new List<IExecutor>();

        private static volatile int _orderNumber = 0;

        public void RegisterExecutor(IExecutor executor)
        {
            Executors.Add(executor);
        }

        public void UnregisterExecutor(IExecutor executor)
        {
            Executors.Remove(executor);
        }

        public IJob ExecuteJob(string executable, string arguments, Action callback=null)
        {
            Console.WriteLine("New Request Arrived");
            var job = new Job(executable, arguments, callback);

            JobList.Add(job);
            IExecutor executor = Executors[_orderNumber % Executors.Count];
            Func<IJob, bool> del = executor.ExecuteJob;
            job.Status = JobStatus.Executing;
            del.BeginInvoke(job, (result) =>
            {
                bool jobResult = del.EndInvoke(result);
                job.Status = (jobResult) ? JobStatus.Completed : JobStatus.Failed;
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
