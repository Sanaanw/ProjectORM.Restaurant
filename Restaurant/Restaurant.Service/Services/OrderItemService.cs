using Restaurant.Core.Entities;
using Restaurant.DataAccess.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Service.Services
{
    public class OrderItemService
    {
        private readonly RestaurantContext _orderItemcontext;
        public OrderItemService()
        {
            _orderItemcontext = new RestaurantContext();
        }
        public void AddOrderItem(OrderItem orderItem)
        {
          
        }
    }
}
