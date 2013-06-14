using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using log4net;
using System.IO;
using System.Reflection;
using Comunicacion;
using ServidorEstadisticas.queue;
using ort.edu.uy.obligatorio2.ServidorEstadisticas.remoting;

namespace uy.edu.ort.obligatorio2.ServidorEstadisticas
{
    class Program
    {
        private ILog log;
        public bool running = true;
        private RemotingServer remotingServer;

        static void Main(string[] args)
        {
            Program p = new Program();
            Console.WriteLine();
            Console.WriteLine("Enter para terminar.");
            Console.ReadLine();
        }

        public Program()
        {
            log4net.Config.XmlConfigurator.Configure(new FileInfo("log4net.config"));
            log4net.GlobalContext.Properties["serverName"] = "Statistics Server";
            log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);


            //string listenAddressStr = Settings.GetInstance().GetProperty("listen.ip", "ANY");
           
            Console.Title = "Statistics Server";
            Console.WriteLine("----- Statistics Server -----");
            Console.WriteLine("[{0}] Starting server...", DateTime.Now);



            SetUpServices();
            Console.WriteLine("[{0}] Server is running properly!", DateTime.Now);
            log.Info("Server is running properly!");

           
        }

        private void SetUpServices()
        {
            QueueHandler.GetInstance();//configura la cola
            StartRemotingServer();



            //iniciar servidor de de remoting
        }


        private void StartRemotingServer()
        {
            this.remotingServer = new RemotingServer();
            remotingServer.StartRemotingServer();
        }
    }
}
