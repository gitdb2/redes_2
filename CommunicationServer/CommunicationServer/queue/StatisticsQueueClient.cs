using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using log4net;
using System.Messaging;
using Comunicacion;
using uy.edu.ort.obligatorio.Commons.queue;

namespace uy.edu.ort.obligatorio2.CommunicationServer.queue
{
    public class StatisticsQueueClient
    {
        private static ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        private MessageQueue messageQueue;
        private static StatisticsQueueClient instance = new StatisticsQueueClient();

        private StatisticsQueueClient()
        {
            InitializeQueue();
        }

        public static StatisticsQueueClient GetInstance()
        {
            return instance;
        }


        private void InitializeQueue()
        {
            //using (var mq = new MessageQueue(@"FormatName:DIRECT=TCP:192.168.0.242\Private$\MyQueue"))
            //// using (var mq = new MessageQueue(@"FormatName:DIRECT=OS:rodrigo-nb\Private$\MyQueue"))
            //{
            //    mq.Send(mm);
            //}


            string queuePath = Settings.GetInstance().GetProperty("remote.queue.name", @"FormatName:DIRECT=TCP:192.168.0.242\Private$\StatsServerQueue");
            //if (!MessageQueue.Exists(queuePath))
            //{
            //    messageQueue = MessageQueue.Create(queuePath);
            //}
            //else
            //{
            messageQueue = new MessageQueue(queuePath);
            //}
            messageQueue.Formatter = new BinaryMessageFormatter();
        }


        public void Release()
        {
            messageQueue.Close();
        }
        public void SendMessages(MessageBean message)
        {
            messageQueue.Send(message);
        }

    }
}
