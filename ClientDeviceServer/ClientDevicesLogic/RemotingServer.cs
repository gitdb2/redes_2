using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Remoting.Channels.Tcp;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting;

namespace ort.edu.uy.obligatorio2.ClientDevicesLogic
{
    public class RemotingServer
    {
        public static void StartRemotingServer()
        {
            Console.WriteLine("Communication Server started...");
            TcpChannel tcpChannel = new TcpChannel(9998);
            ChannelServices.RegisterChannel(tcpChannel, false);
            Type commonInterfaceType = typeof(DevicesData);
            RemotingConfiguration.RegisterWellKnownServiceType(commonInterfaceType, "CommServer", WellKnownObjectMode.SingleCall);
          
        }

    }
}
