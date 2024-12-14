using Microsoft.EntityFrameworkCore;
using Restaurant.Core.Entities;
using Restaurant.DataAccess.Data;
using Restaurant.Service.Exceptions;
using System.Linq;

namespace Restaurant.Service.Services
{
    public class OrderService
    {
        private readonly RestaurantContext _Ordercontext;
        public OrderService()
        {
            _Ordercontext = new RestaurantContext();
        }
        public void UpdateOrder(int id, Order order)
        {
            var ExistOrder = GetOrderWithNoForOrderItem(id);
            if (ExistOrder.TotalAmount is null)
                ExistOrder.TotalAmount = 0;
            ExistOrder.TotalAmount = order.TotalAmount ?? order.TotalAmount;
            ExistOrder.Date = ExistOrder.Date ?? ExistOrder.Date;
            _Ordercontext.SaveChanges();
        }
        public void CreateOrder(Order order)
        {
            if (_Ordercontext.orders.Any(x => x.Id == order.Id))
                throw new AlreadyExistsException($"The order with {order.Id} ID is already exist");
            _Ordercontext.orders.Add(order);
            _Ordercontext.SaveChanges();
        }
        public void GetOrderWithDateInterval(DateTime startDate, DateTime endDate)
        {
            if (startDate > endDate)
                throw new WrongIntervalException("StartingDate can't be greater that EndingDate");
            var Orders = _Ordercontext.orders.Include(x => x.orderItems).Where(a => a.Date >= startDate && a.Date <= endDate)
           .Select(o => new
           {
               OrderId = o.Id,
               TotalAmount = o.TotalAmount,
               TotalMenuItems = o.orderItems.Sum(oi => oi.Count),
               OrderDate = o.Date
           }).ToList();
            if (Orders.Count == 0)
                throw new NotFoundException("Not found Order in this interval");
            foreach (var item in Orders)
            {
                Console.WriteLine($"ID:{item.OrderId}, Total Amount:{item.TotalAmount}, Total Items:{item.TotalMenuItems}, Date:{item.OrderDate}");
            }
        }
        public void GetOrderWithDate(DateTime date)
        {
            var Orders = _Ordercontext.orders.Include(x => x.orderItems).Where(a => a.Date == date)
           .Select(o => new
           {
               OrderId = o.Id,
               TotalAmount = o.TotalAmount,
               TotalMenuItems = o.orderItems.Sum(oi => oi.Count),
               OrderDate = o.Date
           }).ToList();
            if (Orders.Count == 0)
                throw new NotFoundException("Not found Order in this Date");
            foreach (var item in Orders)
            {
                Console.WriteLine($"ID:{item.OrderId}, Total Amount:{item.TotalAmount}, Total Items:{item.TotalMenuItems}, Date:{item.OrderDate}");
            }
        }
        public void GetOrderWithPriceInterval(double minPrice, double maxPrice)
        {
            if (minPrice > maxPrice)
                throw new ArgumentException("Min price can't be greater than max price");
            var Orders = _Ordercontext.orders.Include(x => x.orderItems).Where(x => x.TotalAmount >= minPrice && x.TotalAmount <= maxPrice)
            .Select(o => new
            {
                OrderId = o.Id,
                TotalAmount = o.TotalAmount,
                TotalMenuItems = o.orderItems.Sum(oi => oi.Count),
                OrderDate = o.Date
            }).ToList();
            if (Orders.Count == 0)
                throw new NotFoundException("Not found Order in this interval");
            foreach (var item in Orders)
            {
                Console.WriteLine($"ID:{item.OrderId}, Total Amount:{item.TotalAmount}, Total Items:{item.TotalMenuItems}, Date:{item.OrderDate}");
            }

        }
        public Order GetOrderWithNoForOrderItem(int id)
        {
            var Order = _Ordercontext.orders.SingleOrDefault(x => x.Id == id);
            if (Order is null)
                throw new NotFoundException("Not found Order in this No");
            return Order;
        }
        public void GetOrderWithNo(int id)
        {
            var order = _Ordercontext.orders.Include(o => o.orderItems).ThenInclude(oi => oi.menuItem).Where(o => o.Id == id)
                .Select(o => new
                {
                    OrderId = o.Id,
                    TotalAmount = o.TotalAmount,
                    TotalMenuItems = o.orderItems.Sum(oi => oi.Count),
                    OrderDate = o.Date,
                    OrderItems = o.orderItems.Select(oi => new
                    {
                        ItemId = oi.menuItem.Id,
                        ItemName = oi.menuItem.Name,
                        ItemCount=o.orderItems.Where(o => o.MenuItemID == o.menuItem.Id).Count(),
                    }).ToList()
                })
                .FirstOrDefault();
            if (order == null)
            {
                throw new NotFoundException("Not found Order in this No");
            }
            Console.WriteLine($"Order ID: {order.OrderId}");
            Console.WriteLine($"Total Amount: {order.TotalAmount}");
            Console.WriteLine($"Total Menu Items: {order.TotalMenuItems}");
            Console.WriteLine($"Order Date: {order.OrderDate}");
            Console.WriteLine("Order Items:");
            foreach (var item in order.OrderItems)
            {
                Console.WriteLine($" - Item ID: {item.ItemId}, Name: {item.ItemName}, {item.ItemCount} ");
            }
        }
        public void GetAllOrders()
        {
            var Orders = _Ordercontext.orders.Include(x => x.orderItems)
             .Select(o => new
             {
                 OrderId = o.Id,
                 TotalAmount = o.TotalAmount,
                 TotalMenuItems = o.orderItems.Sum(oi => oi.Count),
                 OrderDate = o.Date
             }).ToList();
            if (Orders.Count() == 0)
                throw new ArgumentNullException("Do not found Order");
            foreach (var item in Orders)
            {
                Console.WriteLine($"ID:{item.OrderId}, Total Amount:{item.TotalAmount}, Total Items:{item.TotalMenuItems}, Date:{item.OrderDate}");
            }
        }

    }
}
