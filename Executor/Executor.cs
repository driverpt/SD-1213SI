using System;
using System.Diagnostics;
using System.IO;
using System.Threading;
using Contracts;

namespace Executor
{
    [Serializable]
    public class Executor : MarshalByRefObject, IExecutor
    {
        public string ExecuteJob(string execFileName, string arguments)
        {
            Console.WriteLine("Work has arrived");

            ProcessStartInfo processInfo = new ProcessStartInfo(execFileName, arguments)
                {
                    CreateNoWindow = true,
                    UseShellExecute = false,
                    RedirectStandardInput = true,
                    RedirectStandardOutput = true,
                };
            Process newProc = Process.Start(processInfo);
            // redireccionamento do Standard Input (teclado) e do standard output (ecrã)
            StreamReader fin = new StreamReader(@"D:\Disciplinas\SD\MEIC-SD-Inv1213\LaunchProgs\Prog1\bin\Debug\stdin.txt");
            StreamWriter fout = new StreamWriter(@"D:\Disciplinas\SD\MEIC-SD-Inv1213\LaunchProgs\Prog1\bin\Debug\stdout.txt");
            StreamWriter swr = newProc.StandardInput;
            streamCopy(fin, swr); fin.Close(); swr.Close();
            StreamReader srd = newProc.StandardOutput;
            streamCopy(srd, fout);

            newProc.WaitForExit(); //newProc.WaitForExit(Timeout*1000);
            fout.Close();
            srd.Close();
            int exitcode = newProc.ExitCode;

            if (exitcode != 0)
            {
                return JobStatus.Failed.ToString();
            }
            Console.WriteLine("Work Success");
            return JobStatus.Success.ToString();
        }

        private static void streamCopy(StreamReader fr, StreamWriter fw)
        {
            string line;
            while ((line = fr.ReadLine()) != null)
            {
                fw.WriteLine(line);
            }
        }
    }
}
