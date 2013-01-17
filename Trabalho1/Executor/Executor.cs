using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using Contracts;

namespace Executor
{
    public class Executor : MarshalByRefObject, IExecutor
    {
        /// <summary>
        /// Stars a new process using the specified executable and arguments. Returns true
        /// when the process runs successfully, false otherwise. 
        /// </summary>
        /// <param name="exec">The process executable file name.</param>
        /// <param name="args">Command-line arguments to use when starting the process.</param>
        /// <returns>true when the process runs successfully, false otherwise.</returns>
        public bool ExecuteJob(string exec, string args)
        {
            try
            {
                Console.WriteLine("Starting process {0}...", exec);
                return StartProcess(exec, args) == 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Process {0} failed: {1}", exec, ex.Message);
                return false;
            }
        }
        
        /// <summary>
        /// Stars a new process using the specified executable and arguments. The working directory
        /// is retrieved from the SharedFolder settings, in app.config. After the process ends,
        /// its exit code is returned.
        /// </summary>
        /// <param name="exec">The process executable file name.</param>
        /// <param name="args">Command-line arguments to use when starting the process.</param>
        /// <returns>Process exit code.</returns>
        private static int StartProcess(string exec, string args)
        {
            string path = SharedFolder.Settings.Path;

            var processInfo = new ProcessStartInfo(path + exec)
                {
                    CreateNoWindow = true,
                    UseShellExecute = false,
                    RedirectStandardInput = true,
                    RedirectStandardOutput = true,
                    WorkingDirectory = path,
                    Arguments = args
                };

            Process newProc = Process.Start(processInfo);

            var fin = new StreamReader(String.Format("{0}{1}.{2}", path, exec, "stdin.txt"));
            StreamWriter swr = newProc.StandardInput;
            StreamCopy(fin, swr);
            fin.Close(); swr.Close();

            var fout = new StreamWriter(String.Format("{0}{1}.{2}", path, exec, "stdout.txt"));
            StreamReader srd = newProc.StandardOutput;
            StreamCopy(srd, fout);

            newProc.WaitForExit();
            fout.Close(); srd.Close();
            
            return newProc.ExitCode;
        }

        private static void StreamCopy(StreamReader fr, StreamWriter fw)
        {
            string line = null;
            while ((line = fr.ReadLine()) != null)
            {
                fw.WriteLine(line);
            }
        }
    }
}
