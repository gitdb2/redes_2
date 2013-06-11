using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using uy.edu.ort.obligatorio.Commons.frameDecoder;

namespace uy.edu.ort.obligatorio2.CommunicationServer
{
    public class SingletonDeviceInfoHandler
    {

        private static SingletonDeviceInfoHandler instance = new SingletonDeviceInfoHandler();
        private Dictionary<string, DeviceInfo> devicesInfo;

        private SingletonDeviceInfoHandler() 
        {
            this.devicesInfo = new Dictionary<string, DeviceInfo>();
        }

        public static SingletonDeviceInfoHandler GetInstance()
        {
            return instance;
        }

        public void UpdateDeviceStatus(FaultFrameDecoded message)
        {
            DeviceFailureInfo newFailure = new DeviceFailureInfo()
            {
                AlarmLevel = message.AlarmLevel,
                AlarmDateTime = message.AlarmDateTime,
                AlarmType = message.AlarmType
            };
            try
            {
                DeviceInfo deviceInfo = null;
                devicesInfo.TryGetValue(message.DeviceId, out deviceInfo);
                deviceInfo.LastFailureInfo = newFailure;
            }
            catch (Exception) 
            { 
                this.devicesInfo.Add(message.DeviceId, new DeviceInfo() { LastFailureInfo = newFailure });
            }
        }

        public void UpdateDeviceStatus(StatusFrameDecoded message)
        {
            DeviceStatusInfo newStatus = new DeviceStatusInfo()
            {
                DeviceId = message.DeviceId,
                StatusOnOff = message.StatusOnOff,
                UpTime = message.UpTime
            };
            try
            {
                DeviceInfo deviceInfo = null;
                devicesInfo.TryGetValue(message.DeviceId, out deviceInfo);
                deviceInfo.LastStatusInfo = newStatus;
            }
            catch (Exception)
            {
                this.devicesInfo.Add(message.DeviceId, new DeviceInfo() { LastStatusInfo = newStatus });
            }
        }

    }
}
