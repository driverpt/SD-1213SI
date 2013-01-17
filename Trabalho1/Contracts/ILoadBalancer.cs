using System;
using System.Runtime.Serialization;

namespace Contracts
{
    public interface ILoadBalancer
    {
        void RegisterExecutor(string executorUri);
        void UnregisterExecutor(string executorUri);
        IJob ExecuteJob(string executable, string arguments);
        JobStatus GetJobStatus(int jobId);
    }

    /// <summary>
    /// The exception that is thrown when there aren't available executors.
    /// </summary>
    [Serializable]
    public class NoExecutorsAvailableException : InvalidOperationException
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="T:LoadBalancer.NoExecutorsAvailableException"/> class.
        /// </summary>
        public NoExecutorsAvailableException()
            : base("No executors available.")
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:LoadBalancer.NoExecutorsAvailableException"/> class with serialized data.
        /// </summary>
        /// <param name="info">The object that holds the serialized object data. </param>
        /// <param name="context">The contextual information about the source or destination. </param>
        protected NoExecutorsAvailableException(SerializationInfo info, StreamingContext context) : base(info, context) { }
    }
}
