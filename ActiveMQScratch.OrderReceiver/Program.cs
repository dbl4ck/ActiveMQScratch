using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ActiveMQScratch.Models;
using Apache.NMS;
using Apache.NMS.Util;
using Newtonsoft.Json;

namespace ActiveMQScratch.OrderReceiver
{
    class Program
    {

        private static readonly Uri _mqBrokerUri = new Uri("activemq:tcp://127.0.0.1:61616");
        private static readonly string _mqQueue = "queue://amqp.orders";

        static void Main(string[] args)
        {

            // connect to message queue instance
            IConnectionFactory factory = new NMSConnectionFactory(_mqBrokerUri);

            using (IConnection connection = factory.CreateConnection())
            using (ISession session = connection.CreateSession())
            {
                connection.Start();
                var destination = CreateDestination(session, _mqQueue);
                var consumer = CreateConsumer(session, destination);

                // add a listener
                consumer.Listener += new MessageListener(OnMessage);

                while (true)
                {
                    // arbitrary main thread loop
                    Wait(100);
                }
            }

        }
        
        public static void OnMessage(IMessage message)
        {
            Order order = null;
            if (message != null)
            {
                order = JsonConvert.DeserializeObject<Order>(((ITextMessage)message).Text);
            }

            if (order != null)
            {
                Console.WriteLine(
                    $"Received OrderId={order.OrderId}, Quantity={order.Quantity}, TotalPrice = {order.TotalPrice}");
            }

        }

        private static IDestination CreateDestination(ISession session, string queue)
        {
            return SessionUtil.GetDestination(session, queue);
        }

        private static IMessageConsumer CreateConsumer(ISession session, IDestination destination)
        {
            return session.CreateConsumer(destination);
        }
        
        public static void Wait(int ms)
        {
            System.Threading.Thread.Sleep(ms);
        }
        
    }
}
