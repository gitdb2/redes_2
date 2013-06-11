using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Remoting.Channels.Tcp;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting;
using log4net;
using Comunicacion;

namespace ort.edu.uy.obligatorio2.ClientDevicesLogic
{
    public class RemotingServer
    {
        private static ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public static void StartRemotingServer()
        {
            log.Info("Communication Server started");
            TcpChannel tcpChannel = new TcpChannel(int.Parse(Settings.GetInstance().GetProperty("commserver.port", "9998")));
            ChannelServices.RegisterChannel(tcpChannel, false);
            Type commonInterfaceType = typeof(DevicesData);
            RemotingConfiguration.RegisterWellKnownServiceType(commonInterfaceType, Settings.GetInstance().GetProperty("commserver.name", "CommServer"), WellKnownObjectMode.SingleCall);
        }

    }
}
