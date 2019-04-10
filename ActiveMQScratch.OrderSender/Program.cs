using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using ActiveMQScratch.Models;
using Newtonsoft.Json;

namespace ActiveMQScratch.OrderSender
{
    class Program
    {
        static void Main(string[] args)
        {            
            // reuse existing httpclient to save socket reserves,
            using (var http = new HttpClient() { BaseAddress = new Uri("http://localhost:58401") })
            {
                // Send orders to WebAPI every second
                while (true)
                {
                    var order = new Order();
                    var serialized = JsonConvert.SerializeObject(order);
                    var content = new StringContent(serialized, Encoding.UTF8, "application/json");

                    Console.WriteLine($"Sending Order {order.OrderId}");
                    var task = http.PostAsync("/api/orders", content);
                    task.Wait();

                    Wait(1);
                }
            }
        }

        public static void Wait(int seconds)
        {
            var ms = (int)TimeSpan.FromSeconds(seconds).TotalMilliseconds;
            System.Threading.Thread.Sleep(ms);
        }

    }
}
