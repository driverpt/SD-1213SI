using System;
using System.Collections;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Http;
using System.Runtime.Serialization.Formatters;
using Contracts;

namespace Executor
{
    public class ExecutorLauncher
    {
        public static void Main(string[] args)
        {
            //IDictionary props = new Hashtable();
            //SoapClientFormatterSinkProvider clientProvider = new SoapClientFormatterSinkProvider();
            //SoapServerFormatterSinkProvider serverProvider = new SoapServerFormatterSinkProvider();
            //serverProvider.TypeFilterLevel = TypeFilterLevel.Full;

            //HttpChannel channel = new HttpChannel(props, clientProvider, serverProvider);

            ////RemotingConfiguration.RegisterActivatedClientType(typeof(JobImpl), "http://localhost:9001/");

            //ChannelServices.RegisterChannel(channel, false);

            ILoadBalancer balancer = (ILoadBalancer)Activator.GetObject(typeof(ILoadBalancer), "http://localhost:9001/LoadBalancer.soap");
            IExecutor executor = new Executor();
            balancer.RegisterExecutor(executor);
        }
    }
}