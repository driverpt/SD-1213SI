using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contracts;

namespace Client
{
    internal class JobAdapter : ViewModelBase, IJob
    {
        private int? _id;
        private JobStatus _status;

        public JobAdapter(string executable, string arguments)
        {
            Executable = executable;
            Arguments = arguments;
            Status = JobStatus.New;
        }

        public string Executable { get; private set; }
        public string Arguments { get; private set; }

        int IJob.Id
        {
            get { return Id ?? -1; }
            set { Id = value; }
        }

        public int? Id
        {
            get { return _id; }
            set
            {
                if (_id == value)
                    return;
                _id = value;
                OnPropertyChanged("Id");
            }
        }

        public JobStatus Status
        {
            get { return _status; }
            set
            {
                if (_status == value)
                    return;
                _status = value;
                OnPropertyChanged("Status");
            }
        }

        /// <summary>
        /// Updates mutable properties from the data of the specified IJob.
        /// </summary>
        /// <param name="job"></param>
        public void UpdateFrom(IJob job)
        {
            Id = job.Id;            
            Status = job.Status;
            Executable = job.Executable;
            Arguments = job.Arguments;
        }
    }
}
