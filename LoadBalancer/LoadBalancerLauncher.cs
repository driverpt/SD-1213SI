using System;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Http;
using Contracts;

namespace TrabalhoPratico1
{
    public class LoadBalancerLauncher
    {
        public const int HTTP_SERVER_PORT = 9001;

        public static void Main( string[] args )
        {
            RemotingConfiguration.RegisterWellKnownServiceType(typeof(LoadBalancer), "LoadBalancer.soap", WellKnownObjectMode.Singleton);
            
            RemotingConfiguration.RegisterWellKnownClientType(typeof(IExecutor), "Executors.soap");

            RemotingConfiguration.RegisterWellKnownClientType(typeof(IJob), "Job.soap");
            //RemotingConfiguration.RegisterActivatedServiceType(typeof(IJob));


            //IDictionary props = new Hashtable();
            //SoapServerFormatterSinkProvider serverProvider = new SoapServerFormatterSinkProvider();
            //serverProvider.TypeFilterLevel = TypeFilterLevel.Full;

            //props["port"] = HTTP_SERVER_PORT;

            HttpChannel channel = new HttpChannel(HTTP_SERVER_PORT);

            ChannelServices.RegisterChannel(channel, false);


            Console.ReadKey();
        }
    }
}