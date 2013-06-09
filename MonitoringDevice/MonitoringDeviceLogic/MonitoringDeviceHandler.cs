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
        public bool IsConnected { get; set; }

        private int portCommServer = int.Parse(Settings.GetInstance().GetProperty("commserver.port", "2000"));
        private string ipCommServer = Settings.GetInstance().GetProperty("commserver.ip", "127.0.0.1");
        private Connection connection;

        public MonitoringDeviceHandler() 
        {
            IsConnected = false;
            this.IsTurnedOn = true;
        }

        public void Connect(string deviceName)
        {
            this.DeviceName = deviceName;
            connection = new Connection(deviceName, new TcpClient(ipCommServer, portCommServer), new ReceiveEventHandler());
            this.IsConnected = true;
        }

        public void Disconnect()
        {
            if (this.connection != null)
            {
                this.connection.CloseConn();
            }
            IsConnected = false;
        }

        public int GetTimerInterval()
        {
            return int.Parse(Settings.GetInstance().GetProperty("statusreport.interval", "5000"));
        }

        public void SendStatusReport(long uptimeMillis)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(this.DeviceName).Append(ParseConstants.SEPARATOR_PIPE);
            sb.Append(this.IsTurnedOn ? "1" : "0").Append(ParseConstants.SEPARATOR_PIPE);
            sb.Append(uptimeMillis);
            SendMessage(Command.REQ, OpCodeConstants.REQ_SEND_STATUS_REPORT, new Payload(sb.ToString()));
        }

        public void SendFailureReport(int alertLevel, int failureType, string formattedDate)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(this.DeviceName).Append(ParseConstants.SEPARATOR_PIPE);
            sb.Append(failureType).Append(ParseConstants.SEPARATOR_PIPE);
            sb.Append(alertLevel).Append(ParseConstants.SEPARATOR_PIPE);
            sb.Append(formattedDate);
            SendMessage(Command.REQ, OpCodeConstants.REQ_SEND_FAILURE_REPORT, new Payload(sb.ToString()));
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
