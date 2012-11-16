using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Lifetime;
using System.Text;
using System.Threading;
using Contracts;

namespace Executor
{
    [Serializable]
    public class Executor : MarshalByRefObject, IExecutor
    {
        public bool ExecuteJob(IJob job)
        {
            Thread.Sleep(5000);
            job.Status = JobStatus.Completed;
            return true;
        }
    }
}
