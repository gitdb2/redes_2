using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Messaging;
using System.Threading;

namespace Server
{
    class Program
    {
        // Define static class members. 
        static ManualResetEvent signal = new ManualResetEvent(false);
        static int count = 0;

        //************************************************** 
        // Provides an entry point into the application. 
        //		  
        // This example performs asynchronous receive 
        // operation processing. 
        //************************************************** 

        public static void Main()
        {
            // Create an instance of MessageQueue. Set its formatter.
            using (var myQueue = new MessageQueue(@".\Private$\MyQueue"))
            {
                //MessageQueue myQueue = new MessageQueue(".\\myQueue");
                myQueue.Formatter = new XmlMessageFormatter(new Type[] { typeof(String) });

                // Add an event handler for the ReceiveCompleted event.
                myQueue.ReceiveCompleted +=
                    new ReceiveCompletedEventHandler(MyReceiveCompleted);

                // Begin the asynchronous receive operation.
                myQueue.BeginReceive();

                signal.WaitOne();

                // Do other work on the current thread. 

                return;
            }
        }


        //*************************************************** 
        // Provides an event handler for the ReceiveCompleted 
        // event. 
        //*************************************************** 

        private static void MyReceiveCompleted(Object source,
            ReceiveCompletedEventArgs asyncResult)
        {
            try
            {
                // Connect to the queue.
                MessageQueue mq = (MessageQueue)source;

                // End the asynchronous receive operation.
                Message m = mq.EndReceive(asyncResult.AsyncResult);
                string txt = "";
                //count += 1;
                //if (count == 10)
                //{
                //    signal.Set();
                //}

                try
                {

                    m.Formatter = new XmlMessageFormatter(new String[] { "System.String,mscorlib" });
                    txt = m.Body.ToString();
                }
                catch
                {
                    txt = "No Message - Excepiton";
                }
                Console.WriteLine(txt);

                // Restart the asynchronous receive operation.
                mq.BeginReceive();
            }
            catch (MessageQueueException)
            {
                // Handle sources of MessageQueueException.
            }

            // Handle other exceptions. 

            return;
        }
    }
}
