using Restaurant.Core.Entities;
using Restaurant.Service.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.App.Controllers
{
    public class OrderItemController
    {
        private readonly OrderItemService _orderItemService;
        public OrderItemController()
        {
            _orderItemService = new OrderItemService();
        }
       public void AddOrderItem(OrderItem _orderItem)
        {
            _orderItemService.AddOrderItem(_orderItem);
        }
        public void RemoveOrderItem(int _id)
        {
            _orderItemService.DeleteOrderItem(_id);
        }
    }
}
