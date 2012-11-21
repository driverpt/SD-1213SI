namespace Contracts
{
    public interface IExecutor
    {
        string ExecuteJob(string execFileName, string arguments);
    }
}