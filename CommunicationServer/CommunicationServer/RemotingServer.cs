using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Remoting.Channels.Tcp;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting;
using log4net;
using Comunicacion;

namespace uy.edu.ort.obligatorio2.CommunicationServer
{
    public class RemotingServer
    {
        private static ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public void StartRemotingServer()
        {
            log.Info("Remoting Server started");
            TcpChannel tcpChannel = new TcpChannel(int.Parse(Settings.GetInstance().GetProperty("remoting.commserver.port", "9998")));
            ChannelServices.RegisterChannel(tcpChannel, false);
            Type commonInterfaceType = typeof(ICommServerImpl);
            RemotingConfiguration.RegisterWellKnownServiceType(commonInterfaceType, Settings.GetInstance().GetProperty("remoting.commserver.name", "CommServer"), WellKnownObjectMode.SingleCall);
        }

    }
}
