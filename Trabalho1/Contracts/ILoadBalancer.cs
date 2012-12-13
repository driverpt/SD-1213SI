namespace Contracts
{
    public interface ILoadBalancer
    {
        void RegisterExecutor(IExecutor executor);
        void UnregisterExecutor(IExecutor executor);
    }
}
