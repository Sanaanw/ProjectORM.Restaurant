using Microsoft.EntityFrameworkCore;
using Restaurant.Core.Entities;
using Restaurant.DataAccess.Data;
using Restaurant.Service.Exceptions;
using System.Security.Cryptography;

namespace Restaurant.Service.Services
{
    public class OrderItemService
    {
        private readonly MenuItemService _menuItemService;
        private readonly OrderService _orderService;
        private readonly RestaurantContext _orderItemcontext;
        private readonly RestaurantContext _Menucontext;

        public OrderItemService()
        {
            _Menucontext=new RestaurantContext();
            _orderService = new OrderService();
            _menuItemService = new MenuItemService();
            _orderItemcontext = new RestaurantContext();
        }
        public void DeleteOrderItem(int orderID)
        {
            var NewOrderItem = _orderItemcontext.orderItems.SingleOrDefault(x => x.Id == orderID);
            if (NewOrderItem is null)
                throw new NotFoundException($"Not found OrderItem with {orderID} ID");
            _orderItemcontext.orderItems.Remove(NewOrderItem);
            _orderItemcontext.SaveChanges();
        }
        public async Task DeleteOrderItemAsync(int orderID)
        {
            var NewOrderItem = await _orderItemcontext.orderItems.SingleOrDefaultAsync(x => x.Id == orderID);
            if (NewOrderItem is null)
                throw new NotFoundException($"Not found OrderItem with {orderID} ID");
            _orderItemcontext.orderItems.Remove(NewOrderItem);
            await _orderItemcontext.SaveChangesAsync();
        }
    }
}
