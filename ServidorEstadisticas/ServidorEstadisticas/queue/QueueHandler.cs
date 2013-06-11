using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Messaging;
using Comunicacion;
using log4net;
using uy.edu.ort.obligatorio.Commons.queue;
using uy.edu.ort.obligatorio2.ServidorEstadisticas;
using uy.edu.ort.obligatorio.Commons.frameDecoder;

namespace ServidorEstadisticas.queue
{
    public class QueueHandler
    {
        private static ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        private MessageQueue messageQueue;
        private bool isRunning;

        public QueueHandler()
        {
            InitializeQueue();
        }

        private void InitializeQueue()
        {
            string queuePath = Settings.GetInstance().GetProperty("local.queue.name", @".\Private$\StatsServerQueue");
            if (!MessageQueue.Exists(queuePath))
            {
                messageQueue = MessageQueue.Create(queuePath);
            }
            else
            {
                messageQueue = new MessageQueue(queuePath);
            }
            isRunning = true;
            messageQueue.Formatter = new BinaryMessageFormatter();
            messageQueue.ReceiveCompleted += OnReceiveCompleted;
            messageQueue.BeginReceive();
        }

         private void OnReceiveCompleted(Object source, ReceiveCompletedEventArgs asyncResult)
        {
            try
            {
                MessageQueue mq = (MessageQueue)source;

                if (mq != null)
                {
                    try
                    {
                        System.Messaging.Message message = null;
                        try
                        {
                            message = mq.EndReceive(asyncResult.AsyncResult);
                        }
                        catch (Exception ex)
                        {
                            log.Error(ex.Message);
                        }
                        if (message != null)
                        {
                            MessageBean messageBean = message.Body as MessageBean;
                            if (messageBean != null)
                            {
                              if(messageBean.MessageType == MessageTypeEnum.FAULT){
                                  FaultFrameDecoded tmp = new FaultFrameDecoded();
                                  tmp.Parse(messageBean.Message);
                                  SingletonStatsHistory.GetInstance().AddFault( tmp);
                                  log.InfoFormat("Fault: {0}", tmp.ToString());
                              }else{
                                  StatusFrameDecoded tmp = new StatusFrameDecoded();
                                  tmp.Parse(messageBean.Message);
                                  SingletonStatsHistory.GetInstance().AddStatus(tmp);
                                   log.InfoFormat("Status: {0}", tmp.ToString());
                              }
                            }else{
                                log.Info("Message vino null");
                            }
                        }
                    }
                    finally
                    {
                        if (isRunning)
                        {
                            mq.BeginReceive();
                        }
                    }
                }
                return;
            }
            catch (Exception exc)
            {
                log.Error(exc.Message);
            }
        }


    }

    }
}
