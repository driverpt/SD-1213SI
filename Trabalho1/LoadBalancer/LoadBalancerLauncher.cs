using System;
using System.Runtime.Remoting;

namespace LoadBalancer
{
    public class LoadBalancerLauncher
    {

        /// <summary>
        /// Starts a new load balancer
        /// </summary>
        /// <param name="args"></param>
        public static void Main( string[] args )
        {
            RemotingConfiguration.Configure("LoadBalancer.exe.config", false);
            Console.WriteLine("Load balancer running. Press enter to shutdown.");
            Console.ReadLine();
        }
    }
}