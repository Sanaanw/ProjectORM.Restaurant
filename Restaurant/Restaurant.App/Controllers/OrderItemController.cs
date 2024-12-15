using Restaurant.Core.Entities;
using Restaurant.Service.Services;

namespace Restaurant.App.Controllers
{
    public class OrderItemController
    {
        private readonly OrderItemService _orderItemService;
        public OrderItemController()
        {
            _orderItemService = new OrderItemService();
        }
        public void RemoveOrderItem(int _id)
        {
            _orderItemService.DeleteOrderItem(_id);
            Console.WriteLine($"Removed order that {_id} ID");
        }
    }
}
