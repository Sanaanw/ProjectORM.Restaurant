using Restaurant.DataAccess.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Service.Services
{
    public class OrderItem
    {
        private readonly RestaurantContext _orderItemcontext;
        public OrderItem()
        {
            _orderItemcontext = new RestaurantContext();
        }
        
    }
}
