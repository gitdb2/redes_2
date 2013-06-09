using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using uy.edu.ort.obligatorio.Commons;
using Comunicacion;

namespace ort.edu.uy.obligatorio2.MonitoringDeviceLogic
{
    public class ReceiveEventHandler : IReceiveEvent
    {

        public bool OnReceiveData(Connection connection)
        {
            Data dato = DataProccessor.GetInstance().LoadObject(connection.StreamReader);
            return CommandHandler.GetInstance().Handle(connection, dato);
        }

        public bool OnFatalError(Connection connection)
        {
            return false;
        }

    }
}
