using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Core.Entities
{
    public class Order : BaseEntity
    {
        public double TotalAmount { get; set; }
        public DateTime Date { get; set; }
        List<OrderItem> orderItems;
    }
}
