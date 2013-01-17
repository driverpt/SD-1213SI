namespace Contracts
{
    public interface IExecutor
    {
        bool ExecuteJob(string execFileName, string arguments);
    }
}