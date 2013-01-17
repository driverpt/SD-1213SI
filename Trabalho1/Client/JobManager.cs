using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting;
using System.Text;
using System.Threading.Tasks;
using Contracts;

namespace Client
{
    public partial class JobManager : BaseForm
    {
        private readonly StringBuilder _stringBuilder;
        private readonly BindingList<JobAdapter> _jobs;
        private readonly ILoadBalancer _loadBalancer;

        public JobManager()
        {
            InitializeComponent();
            RemotingConfiguration.Configure("Client.exe.config", false);
            _stringBuilder = new StringBuilder();
            _jobs = new BindingList<JobAdapter>();
            _bsrc_Jobs.DataSource = _jobs;
            _loadBalancer = RemotingHelper.CreateProxy<ILoadBalancer>();
        }

        private void _btn_Exec_Click(object sender, EventArgs e)
        {
            ExecuteCommand();
            _txb_Command.Clear();
        }      

        private void _tsb_RefreshAll_Click(object sender, EventArgs e)
        {
            RefreshAllJobs();
        }

        private void _tsb_Clear_Click(object sender, EventArgs e)
        {
            ClearOutput();
        }
        
        private void ClearOutput()
        {
            _stringBuilder.Clear();
            _txb_Output.Clear();
        }
     
        private void Log(string format, params object[] args)
        {
            string text = String.Format(format, args);
            _stringBuilder.AppendLine(String.Format("[{0}] {1}", DateTime.Now.ToLongTimeString(), text));
            _txb_Output.Text = _stringBuilder.ToString();
            _txb_Output.Select(_txb_Output.Text.Length - 1, 0);
            _txb_Output.ScrollToCaret();
        }

        private void WhenDone<T>(Task<T> task, Action<Task<T>, bool> action)
        {
            var ui = TaskScheduler.FromCurrentSynchronizationContext();

            task.ContinueWith(t =>
            {
                bool success = t.Exception == null;
                if (!success)
                {
                    foreach (var ex in t.Exception.Flatten().InnerExceptions)
                        Log("Error: {0}", ex.Message.ToString());
                }

                action(t, success);
            }, ui);
        }
    }
}
