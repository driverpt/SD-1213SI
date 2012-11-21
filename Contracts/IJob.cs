using System;

namespace Contracts
{
    public interface IJob
    {
        string Executable { get; }
        string Arguments { get; }
        JobStatus Status { get; set; }
        Action Callback { get; }
    }

    [Serializable]
    public class Job : IJob
    {
        public string Executable { get; private set; }
        public string Arguments { get; private set; }
        public JobStatus Status { get; set; }
        public Action Callback { get; private set; }

        public Job(string executable, string arguments, Action callback=null)
        {
            Executable = executable;
            Arguments = arguments;
            Callback = callback;
            Status = JobStatus.New;
        }
    }

    [Serializable]
    public enum JobStatus
    {
        New, Queued, Executing, Success, Failed
    }
}