using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using ActiveMQScratch.Web.Mq;

namespace ActiveMQScratch.Web
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        private static readonly Uri _mqBrokerUri = new Uri("activemq:tcp://127.0.0.1:61616");

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            // initialize application scope objects
            MqSession.GetInstance(_mqBrokerUri);
        }
    }
}
