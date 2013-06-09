using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using uy.edu.ort.obligatorio.Commons;
using System.Net.Sockets;
using Comunicacion;

namespace ort.edu.uy.obligatorio2.MonitoringDeviceLogic
{
    public class MonitoringDeviceHandler
    {
        public string DeviceName { get; set; }
        public bool IsTurnedOn { get; set; }

        private int portCommServer = int.Parse(Settings.GetInstance().GetProperty("commserver.port", "2000"));
        private string ipCommServer = Settings.GetInstance().GetProperty("commserver.ip", "127.0.0.1");
        private Connection connection;

        public MonitoringDeviceHandler() 
        {
            this.IsTurnedOn = false;
        }

        public void TurnOn(string deviceName)
        {
            this.DeviceName = deviceName;
            //FIXME
            //cuando haya un servidor del otro lado
            //connection = new Connection(deviceName, new TcpClient(ipCommServer, portCommServer), new ReceiveEventHandler());
            this.IsTurnedOn = true;
        }

        public void TurnOff()
        {
            if (this.connection != null)
            {
                this.connection.CloseConn();
            }
            this.IsTurnedOn = false;
        }

        public int GetTimerInterval()
        {
            return int.Parse(Settings.GetInstance().GetProperty("statusreport.interval", "5000"));
        }

        public void SendStatusReport(long uptimeMillis)
        {
            //iddisp|tipo de falla numero|tipo de alerta numero|fecha hora en formato
            StringBuilder sb = new StringBuilder();
            sb.Append(this.DeviceName).Append(ParseConstants.SEPARATOR_PIPE);
            sb.Append(this.IsTurnedOn ? "1" : "0").Append(ParseConstants.SEPARATOR_PIPE);
            sb.Append(uptimeMillis);
            SendMessage(Command.REQ, OpCodeConstants.REQ_SEND_STATUS_REPORT, new Payload(sb.ToString()));
        }

        private void SendMessage(Command command, int opCode, Payload payload)
        {
            Data data = new Data() { Command = command, OpCode = opCode, Payload = payload };
            foreach (var item in data.GetBytes())
            {
                connection.WriteToStream(item);
            }
        }

    }
}
