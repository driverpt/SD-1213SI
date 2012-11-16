using System;

namespace Contracts
{
    public interface ILoadBalancer
    {
        void RegisterExecutor(IExecutor executor);
        void UnregisterExecutor(IExecutor executor);
        IJob ExecuteJob(string executable, string arguments, Action callback=null);
    }
}
