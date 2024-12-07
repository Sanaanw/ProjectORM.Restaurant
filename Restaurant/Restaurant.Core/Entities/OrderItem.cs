using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Core.Entities
{
    public class OrderItem:BaseEntity
    {
        public int Count { get; set; }
        public int MenuItemID { get; set; }
        public MenuItem menuItem { get; set; }
        public int OrderID { get; set; }
        public Order order { get; set; }
    }   
}
