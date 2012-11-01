using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Http;
using Contracts;

namespace TrabalhoPratico1
{
    public class LoadBalancerLauncher
    {
        public static void Main( string[] args )
        {
            RemotingConfiguration.RegisterWellKnownServiceType(typeof(ILoadBalancer), "LoadBalancer.soap", WellKnownObjectMode.Singleton);
            RemotingConfiguration.RegisterWellKnownClientType(typeof(IJob), "Job.soap");
            RemotingConfiguration.RegisterWellKnownClientType(typeof(IExecutor), "Executors.soap");

            RemotingConfiguration.RegisterActivatedServiceType(typeof(LoadBalancer));
            
            IChannel channel = new HttpChannel(9001);
            ChannelServices.RegisterChannel(channel, false);
            
        }
    }
}