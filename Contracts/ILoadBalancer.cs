using System;

namespace Contracts
{
    public interface ILoadBalancer
    {
        void RegisterExecutor(string executorUri);
        void UnregisterExecutor(string executorUri);
        IJob ExecuteJob(string executable, string arguments, Action callback=null);
    }
}
