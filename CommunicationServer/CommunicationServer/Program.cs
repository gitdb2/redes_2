﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Sockets;
using uy.edu.ort.obligatorio.Commons;
using log4net;
using System.IO;
using System.Reflection;
using Comunicacion;

namespace uy.edu.ort.obligatorio2.CommunicationServer
{
    class Program
    {
        private ILog log;
        public bool running = true;
        public TcpListener server;
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
            log4net.GlobalContext.Properties["serverName"] = "Communication Server";
            log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        
            string listenAddressStr = Settings.GetInstance().GetProperty("listen.ip","ANY");
            IPAddress ip = "ANY".Equals(listenAddressStr) ? IPAddress.Any : IPAddress.Parse(listenAddressStr);
            int port =  int.Parse(Settings.GetInstance().GetProperty("listen.port","2000"));

            Console.Title = "Communication Server";
            Console.WriteLine("----- Communication Server -----");
            Console.WriteLine("[{0}] Starting server...", DateTime.Now);

  

            server = new TcpListener(ip, port);
            server.Start();
            Console.WriteLine("[{0}] Server is running properly!", DateTime.Now);
            log.Info("Server is running properly!");

            StartRemotingServer();
            Listen();
        }

        private void StartRemotingServer()
        {
            this.remotingServer = new RemotingServer();
            remotingServer.StartRemotingServer();
        }

        void Listen()
        {
            while (running)
            {
                TcpClient tcpClient = server.AcceptTcpClient();
                Connection client = new Connection(tcpClient, new ReceiveEventHandler());
            }
        }

    }
}
