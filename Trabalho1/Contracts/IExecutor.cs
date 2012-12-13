namespace Contracts
{
    public interface IExecutor
    {
        bool ExecuteJob(IJob job);
    }
}