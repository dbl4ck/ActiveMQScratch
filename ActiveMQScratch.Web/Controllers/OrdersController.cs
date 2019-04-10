using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ActiveMQScratch.Models;
using ActiveMQScratch.Web.Mq;
using Apache.NMS;
using Apache.NMS.ActiveMQ;
using Apache.NMS.Util;
using Newtonsoft.Json;

namespace ActiveMQScratch.Web.Controllers
{
    public class OrdersController : ApiController
    {

        private static readonly string _mqQueue = "queue://amqp.orders";

        // POST: api/Orders
        public void Post([FromBody]Order order)
        {
            AddToMessageQueue( _mqQueue, order);
        }
        
        // PUT: api/Orders/5
        public void Put(int id, [FromBody]string value)
        {
            throw new NotImplementedException();
        }

        // message queue
        private static void AddToMessageQueue(string queue, Order order)
        {
            var session = MqSession.GetInstance().Session;
            IDestination destination = SessionUtil.GetDestination(session, queue);

            using (IMessageProducer producer = session.CreateProducer(destination))
            {
                    producer.DeliveryMode = MsgDeliveryMode.Persistent;

                    var content = JsonConvert.SerializeObject(order);
                    ITextMessage request = session.CreateTextMessage(content);
                    producer.Send(request);
            }
        }

    }
}
