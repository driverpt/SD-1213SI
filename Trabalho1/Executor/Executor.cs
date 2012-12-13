using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contracts;

namespace Executor
{
    public class Executor : MarshalByRefObject, IExecutor
    {
        public bool ExecuteJob(IJob job)
        {
            throw new NotImplementedException();
        }
    }
}
