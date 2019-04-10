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

                while (true)
                {
                    var order = GetNextMessage(session, _mqQueue);

                    if (order != null)
                    {
                        Console.WriteLine(
                            $"Received OrderId={order.OrderId}, Quantity={order.Quantity}, TotalPrice = {order.TotalPrice}");
                    }

                    Wait(50);
                }
            }

        }

        public static void Wait(int ms)
        {
            System.Threading.Thread.Sleep(ms);
        }

        private static Order GetNextMessage(ISession session, string queue)
        {
            Order order = null;
            IDestination destination = SessionUtil.GetDestination(session, queue);

            using (IMessageConsumer consumer = session.CreateConsumer(destination))
            {
                
                ITextMessage message = (ITextMessage) consumer.Receive();
                if (message != null)
                {
                    order = JsonConvert.DeserializeObject<Order>(message.Text);
                }

                // connection.close will be auto-invoked by idisposable.
            }

            return order;
        }






    }
}
