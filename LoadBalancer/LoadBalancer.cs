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

        public void ExecuteJob(IJob job)
        {
            job.Status = "Executing";
            IExecutor executor = Executors[_orderNumber%Executors.Count];
            Func<IJob, bool> del = executor.ExecuteJob;
            del.BeginInvoke(job, (result) =>
                {
                    bool jobResult = del.EndInvoke(result);
                    job.Status = (jobResult) ? "Success" : "Failed";
                    if( job.Callback != null )
                    {
                        job.Callback();
                    }
                }, null);
            JobList.Add(job);
        }

        public void RegisterExecutor(IExecutor executor)
        {
            Executors.Add(executor);
        }

        public void UnregisterExecutor(IExecutor executor)
        {
            Executors.Remove(executor);
        }
    }
}
