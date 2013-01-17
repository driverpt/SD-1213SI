using System;

namespace Contracts
{
    public interface IJob
    {
        int         Id          { get; set; }
        JobStatus   Status      { get; set; }
        string      Executable  { get; }
        string      Arguments   { get; }
    }

    [Serializable]
    public class Job : IJob
    {
        public int          Id          { get; set; }
        public JobStatus    Status      { get; set; }        
        public string       Executable  { get; private set; }
        public string       Arguments   { get; private set; }

        public Job(string executable, string arguments)
        {
            Executable = executable;
            Arguments = arguments;
            Status = JobStatus.New;
        }
    }

    [Serializable]
    public enum JobStatus
    {
        New, Queued, Completed, Executing, Success, Failed
    }
}