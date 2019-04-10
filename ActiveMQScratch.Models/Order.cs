using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActiveMQScratch.Models
{
    public class Order
    {
        // properties
        public Guid OrderId { get; set; }
        public Guid ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal TotalPrice { get; set; }
        
        public Order()
        {
            // some random initialization
            var r = new Random();

            OrderId = Guid.NewGuid();
            ProductId = Guid.NewGuid();
            Quantity = r.Next(1, 25);
            UnitPrice = Math.Round(r.Next(5, 20) / (decimal)r.Next(2, 8), 2);
            TotalPrice = Math.Round(Quantity * UnitPrice, 2);
        }
    }
}
