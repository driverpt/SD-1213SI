using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Contracts;

namespace Client
{
    public partial class JobManager
    {
        private void ExecuteCommand()
        {
            string cmd = _txb_Command.Text;
            JobAdapter job = CreateJob(cmd);

            Log("Submitting job \"{0}\"...", cmd);
            _jobs.Add(job);

            var task = Task<IJob>.Factory.StartNew(
                () => _loadBalancer.ExecuteJob(job.Executable, job.Arguments));

            WhenDone(task, (t, success) =>
            {
                if (success)
                {
                    job.UpdateFrom(t.Result);
                    Log("Job \"{0}\" submitted, id: {1}", cmd, job.Id);
                }
                else
                    job.Status = JobStatus.Failed;
            });
        }

        private void RefreshAllJobs()
        {
            var pendingJobs = _jobs.Where(j => j.Status != JobStatus.Failed && j.Status != JobStatus.Completed);
            

            _tsb_RefreshAll.Enabled = false;

            var task = Task<Dictionary<int, JobStatus>>.Factory.StartNew(() =>
                {
                    var statuses = new Dictionary<int, JobStatus>();

                    // Get status from the server for each pending job
                    foreach (var job in pendingJobs)
                    {
                        if (job.Id == null)
                            continue;
                        JobStatus status = _loadBalancer.GetJobStatus(job.Id.Value);

                        // Store it for later retrieval
                        statuses.Add(job.Id.Value, status);
                    }

                    return statuses;
                });

            WhenDone(task, (t, success) =>
                {
                    _tsb_RefreshAll.Enabled = true;

                    if (!success)
                        return;

                    Dictionary<int, JobStatus> statuses = t.Result;

                    // Set status using results for each pending job
                    foreach (var job in pendingJobs)
                    {
                        if (job.Id == null || !statuses.ContainsKey(job.Id.Value))
                            continue;

                        job.Status = statuses[job.Id.Value];
                        Log("Job {0} updated: {1}", job.Id, job.Status);
                    }
                });
        }

        private static JobAdapter CreateJob(string cmd)
        {
            int execLength = cmd.IndexOf(' ');
            if (execLength == -1)
                execLength = cmd.Length;

            string exec = cmd.Substring(0, execLength);
            string args = String.Empty;

            if (execLength < cmd.Length)
                args = cmd.Substring(execLength + 1);

            return new JobAdapter(exec, args);
        }
    }
}
