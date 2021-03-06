﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Sockets;
using System.IO;
using System.Threading;
using Comunicacion;

namespace uy.edu.ort.obligatorio.Commons
{
    public class Connection
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        private TcpClient tcpClient;
        private NetworkStream networkStream;
        public const string UNKNOWN = "Unknown";
        public StreamReader StreamReader { get; set; }
        public StreamWriter StreamWriter { get; set; }

        Semaphore semWrite;//= new Semaphore(0, 1);
        Semaphore semRead;//= new Semaphore(0, 1);

        /// <summary>
        /// ESTE METODO ES NUEVO
        /// </summary>
        private bool online = true;
        public bool OnlineStatus { get { return online; } set {online= value;} }


        public string Name { get; set; }

        public string Ip { get; set; }
        public int Port { get; set; }
        public int TransferPort { get; set; }
        public int UserCount { get; set; }
        public bool IsServer { get; set; }

        private Thread threadRead;

        public IReceiveEvent EventHandler { get; set; }

        private ConnectionDroppedDelegate onConnectionDropDelegate = null;
        public ConnectionDroppedDelegate OnConnectionDropDelegate { get { return onConnectionDropDelegate; } set { onConnectionDropDelegate = value; } }

        //delegado para que la conexion avise a alguien cuando cae.
        public delegate void ConnectionDroppedDelegate(String idName);

        public Connection(TcpClient c, IReceiveEvent ire)
            : this(UNKNOWN, c, ire, null)
        {
        }
        public Connection(string name, TcpClient c, IReceiveEvent ire)
            : this(name, c, ire, null)
        {

        }
        public Connection( string name, TcpClient c, IReceiveEvent ire, ConnectionDroppedDelegate dropConDelegate)
        {
            onConnectionDropDelegate =  dropConDelegate;
            IsServer = false;
            Name = name;
            tcpClient = c;
            EventHandler = ire;
            semWrite = new Semaphore(0, 1);
            semRead = new Semaphore(0, 1);
            (threadRead = new Thread(new ThreadStart(SetupConn))).Start();
        }

        public void WriteToStream(char[] data)
        {
            semWrite.WaitOne();
            StreamWriter.Write(data);
            StreamWriter.Flush();
            semWrite.Release();
        }

        void SetupConn()
        {
            try
            {
                Console.WriteLine("[{0}] New connection!", DateTime.Now);

                networkStream = tcpClient.GetStream();
                StreamReader = new StreamReader(networkStream, Encoding.UTF8);
                StreamWriter = new StreamWriter(networkStream, Encoding.UTF8);
                semWrite.Release();
                semRead.Release();

                ReceiveData();
            }
            finally
            {
                CloseConn();
            }
        }

        bool notEnd = true;

        private void ReceiveData()
        {
            while (notEnd)
            {
                try
                {
                    notEnd = EventHandler.OnReceiveData(this);
                }
                catch (Exception e)
                {
                    notEnd = EventHandler.OnFatalError(this);

                    Console.WriteLine("Se cerro la conexion de: " + this.Name);
                    log.Error("Catch excepcion y cerrado de conexion", e);
                    Console.WriteLine("Error: " + e.Message);
                    notEnd = false;
                }
            }
            //try
            //{
            //    log.Info("Cerrando la conexion!");
            //    CloseConn();
            //}
            //catch { }

            log.InfoFormat("Termina Receive Data de: {0}!", this.Name);
        }

        public void CloseConn() // Close connection.
        {
            try
            {
                notEnd = false;
                StreamReader.Close();
                StreamWriter.Close();
                networkStream.Close();
                tcpClient.Close();
                Console.WriteLine("[{0}] End of connection: {1}!", DateTime.Now, this.Name);
                log.InfoFormat("End of connection: {0}!", this.Name);
              
            }
            catch (Exception e)
            {
                log.Error("Exception mientras se cerraba la conexion (puede ser porque la cerro el cliente)", e);
                //  Console.WriteLine(e.StackTrace);
             //   Console.WriteLine(e.Message);

            }
            finally
            {
                if (onConnectionDropDelegate != null)
                {
                    ConnectionDroppedDelegate tmp = onConnectionDropDelegate;
                    log.InfoFormat("Conexion {0} anula para el delegado y lo invoca", Name);
                    onConnectionDropDelegate = null;
                    tmp(Name);
                    
                }
                log.Debug("End CloseConn!");
            }
            notEnd = false;
        }

        public void WriteToNetworkStream(byte[] buffer, int offset, int size)
        {
            semWrite.WaitOne();
            networkStream.Write(buffer, offset, size);
            networkStream.Flush();
            semWrite.Release();
        }

        public void FlushNetworkStream()
        {
            semWrite.WaitOne();
            networkStream.Flush();
            semWrite.Release();
        }

        public int ReadFromNetworkStream(ref byte[] buffer, int offset, int size)
        {
            return networkStream.Read(buffer, offset, size);
        }

    }

}
