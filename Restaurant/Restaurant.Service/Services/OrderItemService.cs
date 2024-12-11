using Restaurant.Core.Entities;
using Restaurant.DataAccess.Data;
using Restaurant.Service.Exceptions;

namespace Restaurant.Service.Services
{
    public class OrderItemService
    {
        private readonly RestaurantContext _orderItemcontext;
        private readonly OrderService _orderService;
        private readonly MenuItemService _menuItemService;
        public OrderItemService()
        {
            _orderService = new OrderService();
            _orderItemcontext = new RestaurantContext();
            _menuItemService = new MenuItemService();
        }
        public void AddOrderItem(OrderItem orderItem)
        {
            if (!_orderItemcontext.orders.Any(x => x.Id == orderItem.OrderID))
                throw new NotFoundException($"The order that wiht {orderItem.OrderID} ID doesn't exist");
            MenuItem _menuItem = _menuItemService.GetById(orderItem.MenuItemID);
            double _itemPrice = (double)_menuItem.Price;
            Order _order = _orderService.GetOrderWithNo(orderItem.OrderID);
            if (_order.TotalAmount is null)
                _order.TotalAmount = 0;
            _order.TotalAmount += _itemPrice * orderItem.Count;

            _orderItemcontext.orderItems.Add(orderItem);
            _orderItemcontext.SaveChanges();
        }
    }
}
