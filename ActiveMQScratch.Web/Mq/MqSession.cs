using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using Apache.NMS;
using Apache.NMS.ActiveMQ;
using Apache.NMS.Util;

namespace ActiveMQScratch.Web.Mq
{

    /// <summary>
    /// A reusable singleton instance bound to a single messagequeue endpoint on instantiation.
    /// </summary>

    public class MqSession: IDisposable
    {
        public IConnectionFactory Factory { get; set; }
        public IConnection Connection { get; set; }
        public ISession Session { get; set; }

        public MqSession(Uri broker)
        {
            Factory = new NMSConnectionFactory(broker);
            Connection = Factory.CreateConnection();
            Session = Connection.CreateSession();
        }
        
        public void Dispose()
        {
            Connection?.Dispose();
            Session?.Dispose();
        }

        private static MqSession _instance;

        public static MqSession GetInstance(Uri broker)
        {
            if (_instance != null)
            {
                throw new ArgumentException("This overload should be called exactly once during application startup.");
            }
            else if (_instance == null)
            {
                _instance = new MqSession(broker);
            }

            return _instance;
        }

        public static MqSession GetInstance()
        {
            if (_instance == null)
            {
                throw new ArgumentException("This overload should be used for individual calls during the application lifetime.");
            }

            return _instance;
        }
    }
}