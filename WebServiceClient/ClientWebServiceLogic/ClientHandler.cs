using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ort.edu.uy.obligatorio2.WebServiceClientLogic
{
    public class ClientHandler
    {

        private static ClientHandler instance = new ClientHandler();

        private ClientHandler() { }

        public static ClientHandler GetInstance()
        {
            return instance;
        }

    }
}
