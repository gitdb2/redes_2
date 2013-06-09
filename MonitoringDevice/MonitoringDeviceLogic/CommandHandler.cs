using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using uy.edu.ort.obligatorio.Commons;
using Comunicacion;

namespace ort.edu.uy.obligatorio2.MonitoringDeviceLogic
{
    public class CommandHandler
    {
        private static CommandHandler instance = new CommandHandler();

        private CommandHandler() { }

        public static CommandHandler GetInstance()
        {
            return instance;
        }

        public bool Handle(Connection clientConnection, Data dato)
        {
            if (dato.Command == Command.REQ)
            {
                return  HandleREQ(clientConnection, dato);
            }
            else
            {
               return  HandleRES(clientConnection, dato);
            }
        }

        private bool HandleRES(Connection clientConnection, Data dato)
        {
            bool ret = true;
            switch (dato.OpCode)
            {
                default:
                    break;
            }
            return ret;
        }

        private bool HandleREQ(Connection clientConnection, Data dato)
        {
            bool ret = true;
            switch (dato.OpCode)
            {
                default:
                    break;
            }
            return ret;
        }

    }
}
