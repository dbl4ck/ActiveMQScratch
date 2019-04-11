using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Apache.NMS;
using Apache.NMS.ActiveMQ.Commands;
using Apache.NMS.Util;

namespace ActiveMQScratch.OrderReceiver
{
    class MqListener
    {
        private IMessageConsumer _consumer;

        public MqListener(IMessageConsumer consumeer, string queueName)
        {
            _session = this.session;
            _destination = destina
        }
        
    }
}
