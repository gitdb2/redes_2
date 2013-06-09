using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Comunicacion;
using uy.edu.ort.obligatorio.Commons;

namespace uy.edu.ort.obligatorio2.CommunicationServer
{
    public class ReceiveEventHandler : IReceiveEvent
    {

        public bool OnReceiveData(Connection connection)
        {
            Data dato = DataProccessor.GetInstance().LoadObject(connection.StreamReader);
            CommandHandler.GetInstance().Handle(connection, dato);
            return true;
        }

        public bool OnFatalError(Connection connection)
        {
            CommandHandler.GetInstance().Logout(connection);
            return false;
        }

    }
}
