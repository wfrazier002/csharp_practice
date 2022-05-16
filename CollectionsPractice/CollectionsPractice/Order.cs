using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectionsPractice {
    class Order {
        public int OrderId { get; set; }
        public int OrderQuantity { get; set; }

        public Order(int orderId, int orderQuantity) {
            this.OrderId = orderId;
            this.OrderQuantity = orderQuantity;
        }

        public void ProcessOrder() {
            Console.WriteLine($"Order {OrderId} has been processed.");
        }
    }
}
