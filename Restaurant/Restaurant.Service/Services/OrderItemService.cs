using Microsoft.EntityFrameworkCore;
using Restaurant.Core.Entities;
using Restaurant.DataAccess.Data;
using Restaurant.Service.Exceptions;

namespace Restaurant.Service.Services
{
    public class OrderItemService
    {
        private readonly MenuItemService _menuItemService;
        private readonly OrderService _orderService;
        private readonly RestaurantContext _orderItemcontext;
        public OrderItemService()
        {
            _orderService = new OrderService();
            _menuItemService = new MenuItemService();
            _orderItemcontext = new RestaurantContext();
        }
        public void AddOrderItem(OrderItem orderItem)
        {
            if (!_orderItemcontext.orders.Any(x => x.Id == orderItem.OrderID))
                throw new NotFoundException($"The order that with {orderItem.OrderID} ID doesn't exist");
            MenuItem _menuItem = _menuItemService.GetById(orderItem.MenuItemID);
            double _itemPrice = (double)_menuItem.Price;
            Order _order = _orderService.GetOrderWithNoForOrderItem(orderItem.OrderID);
            if (_order.TotalAmount is null)
                _order.TotalAmount = 0;
            _order.TotalAmount += _itemPrice * orderItem.Count;
            _orderService.UpdateOrder(orderItem.OrderID, new() { TotalAmount = _order.TotalAmount });
            _orderItemcontext.orderItems.Add(orderItem);
            _orderItemcontext.SaveChanges();
        }
        public void DeleteOrderItem(int orderID)
        {
            var NewOrderItem = _orderItemcontext.orderItems.SingleOrDefault(x => x.Id == orderID);
            if (NewOrderItem is null)
                throw new NotFoundException($"Not found OrderItem with {orderID} ID");
            _orderItemcontext.orderItems.Remove(NewOrderItem);
            _orderItemcontext.SaveChanges();
        }
    }
}
