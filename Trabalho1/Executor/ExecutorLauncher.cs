using System;
using System.Collections;
using System.Net;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Http;
using System.Runtime.Serialization.Formatters;
using Contracts;

namespace Executor
{
    public class ExecutorLauncher
    {
        /// <summary>
        /// Starts a new executor.
        /// </summary>
        /// <param name="args"></param>
        public static void Main(string[] args)
        {
            RemotingConfiguration.Configure("Executor.exe.config", false);
            var balancer = RemotingHelper.CreateProxy<ILoadBalancer>();

            string uri = null;

            try
            {
                uri = GetExecutorUri();
                balancer.RegisterExecutor(uri);

                // the server will keep running until keypress.
                Console.WriteLine("Executor running. Press enter to shutdown.");
                Console.ReadLine();
            }
            catch(Exception ex)
            {
                Console.WriteLine("Error while connecting to LoadBalancer: {0}", ex.Message);
            }
            finally
            {
                try
                {
                    // Always unregister executor from load balancer
                    if (uri != null)
                        balancer.UnregisterExecutor(uri);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error while connecting to LoadBalancer: {0}", ex.Message);
                }
            }
        }

        private static string GetExecutorUri()
        {
            string ipAddress = RemotingHelper.GetLocalIPAddress().ToString();

            // Format -> http://<local ip address>:<port number>/<endpoint name>.sopa
            return String.Format("http://{0}:{1}/{2}", ipAddress, 1234, "Executor.soap");
        }
    }
}