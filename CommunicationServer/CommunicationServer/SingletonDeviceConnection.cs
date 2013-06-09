using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using uy.edu.ort.obligatorio.Commons;
using System.Text.RegularExpressions;

namespace uy.edu.ort.obligatorio2.CommunicationServer
{
    public class SingletonDeviceConnection
    {
        Dictionary<string, Connection> devicesMap = new Dictionary<string, Connection>();

        private static SingletonDeviceConnection instance = new SingletonDeviceConnection();

        private SingletonDeviceConnection() { }

        public static SingletonDeviceConnection GetInstance()
        {
            return instance;
        }

        public void AddDevice(string name, Connection connection)
        {
            lock (devicesMap)
            {
                if (!IsConnected(name))//si ya no esta dado de alta
                {
                    connection.Name = name;
                    devicesMap.Add(name, connection);
                }
            }
        }

        public bool RemoveDevice(string name)
        {
            lock (devicesMap)
            {
                return devicesMap.Remove(name);
            }
        }

        public bool IsConnected(string name)
        {
            return devicesMap.ContainsKey(name);
        }


        public Connection GetDevice(string name)
        {
            Connection ret = null;
            lock (devicesMap)
            {
                try
                {
                    devicesMap.TryGetValue(name, out ret);
                }
                catch
                {
                    ret = null;
                }
            }
            return ret;
        }

    
    }
}
