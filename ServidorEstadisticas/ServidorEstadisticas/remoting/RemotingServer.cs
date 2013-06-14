using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Remoting.Channels.Tcp;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting;
using log4net;
using Comunicacion;
using uy.edu.ort.obligatorio.Commons.statsInterface;

namespace ort.edu.uy.obligatorio2.ServidorEstadisticas.remoting
{
    public class RemotingServer
    {
        private static ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public void StartRemotingServer()
        {
            
            TcpChannel tcpChannel = new TcpChannel(int.Parse(Settings.GetInstance().GetProperty("statsserver.port", "9997")));
           
            ChannelServices.RegisterChannel(tcpChannel, false);
            Type commonInterfaceType = typeof(StatsServerImpl);
            RemotingConfiguration.RegisterWellKnownServiceType(
                                    commonInterfaceType, 
                                    Settings.GetInstance().GetProperty("statsserver.name", "StatsServer"), 
                                    WellKnownObjectMode.SingleCall);
            log.Info("Remoting Server ("+(Settings.GetInstance().GetProperty("statsserver.name", "StatsServer"))+")  started in port: " + Settings.GetInstance().GetProperty("statsserver.port", "9997"));
        }

    }
}
