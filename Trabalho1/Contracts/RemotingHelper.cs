using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Remoting;
using System.Text;

namespace Contracts
{
    public class RemotingHelper
    {
        private static IDictionary _wellKnownTypes;

        public static T CreateProxy<T>()
        {
            Type type = typeof (T);

            if (_wellKnownTypes == null) 
                InitTypeCache();
            
            var entr = (WellKnownClientTypeEntry) _wellKnownTypes[type];
            if (entr == null)
            {
                throw new RemotingException("Type not found!");
            }

            return (T) Activator.GetObject(entr.ObjectType, entr.ObjectUrl);
        }

        public static void InitTypeCache()
        {
            Hashtable types = new Hashtable();

            foreach (var entr in RemotingConfiguration.GetRegisteredWellKnownClientTypes())
            {
                if (entr.ObjectType == null)
                {
                    throw new RemotingException("A configured type could not " +
                    "be found. Please check spelling in your configuration file.");
                }
                types.Add(entr.ObjectType, entr);
            }

            _wellKnownTypes = types;
        }

        /// <summary>
        /// Gets the first local ip address.
        /// </summary>
        /// <exception cref="SocketException"></exception>
        public static IPAddress GetLocalIPAddress()
        {
            IPHostEntry host = Dns.GetHostEntry(Dns.GetHostName());
            
            foreach (IPAddress ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                    return ip;
            }

            return IPAddress.Loopback;
        }
    }
}
