using Microsoft.EntityFrameworkCore;
using Restaurant.Core.Entities;
using Restaurant.DataAccess.Data;
using Restaurant.Service.Exceptions;
using System.Linq;

namespace Restaurant.Service.Services
{
    public class OrderService
    {
        private readonly MenuItemService _menuItemService = new MenuItemService();
        private readonly RestaurantContext _Ordercontext = new RestaurantContext();
        private readonly RestaurantContext _orderItemcontext = new RestaurantContext();
        public void UpdateOrder(int id, Order order)
        {
            var ExistOrder = GetOrderWithNoForOrderItem(id);
            if (ExistOrder.TotalAmount is null)
                ExistOrder.TotalAmount = 0;
            ExistOrder.TotalAmount = order.TotalAmount ?? order.TotalAmount;
            ExistOrder.Date = ExistOrder.Date ?? ExistOrder.Date;
            _Ordercontext.SaveChanges();
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Updated order: ");
            Console.ResetColor();
            Console.WriteLine(GetOrderWithNoForOrderItem(id));
        }
        public async Task UpdateOrderAsync(int id, Order order)
        {
            var ExistOrder = GetOrderWithNoForOrderItem(id);
            if (ExistOrder.TotalAmount is null)
                ExistOrder.TotalAmount = 0;
            ExistOrder.TotalAmount = order.TotalAmount ?? order.TotalAmount;
            ExistOrder.Date = ExistOrder.Date ?? ExistOrder.Date;
            await _Ordercontext.SaveChangesAsync();
        }
        public void CreateOrder()
        {
            bool MainLoop = true;
            Order order = new Order();
            _Ordercontext.orders.Add(order);
            _Ordercontext.SaveChanges();
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine($"Created order with {order.Id} ID");
            Console.WriteLine( );
            do
            {
                Console.ResetColor();
                Console.Write("Do you wanna to add Order Item YES/NO: ");
                string Answer = Console.ReadLine()?.Trim().ToUpper();
                if (Answer == "YES")
                {
                    bool ResultForMenuId = true;
                    bool ResultForItemCount = true;
                    int _MenuItemId = default;
                    int _CountItem = default;
                    Console.Clear();
                    while (ResultForMenuId)
                    {
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.WriteLine("Menu Items: ");
                        Console.ResetColor ();
                        foreach (var item in _menuItemService.GetAllItems())
                        {
                            Console.WriteLine(item);
                        }
                        Console.Write("Add ID of Menu item that you wanna add: ");
                        var inputMenuItemId = Console.ReadLine();

                        if (!int.TryParse(inputMenuItemId, out _MenuItemId))
                            Console.WriteLine("Pls add value of ID");
                        else
                            ResultForMenuId = false;
                    }
                    while (ResultForItemCount)
                    {
                        Console.Write("Add count of Menu item: ");
                        var inputCountItem = Console.ReadLine();

                        if (!int.TryParse(inputCountItem, out _CountItem))
                            Console.WriteLine("Pls add Count");
                        else
                            ResultForItemCount = false;
                    }
                    OrderItem orderItem = new()
                    {
                        MenuItemID = _MenuItemId,
                        Count = _CountItem,
                        OrderID = order.Id
                    };
                    MenuItem _menuItem = _menuItemService.GetById(_MenuItemId);
                    double _itemPrice = (double)_menuItem.Price;

                    if (order.TotalAmount is null)
                    {
                        order.TotalAmount = 0;
                    }
                    order.TotalAmount += _itemPrice * orderItem.Count;

                    UpdateOrder(orderItem.OrderID, new() { TotalAmount = order.TotalAmount });
                    _orderItemcontext.orderItems.Add(orderItem);
                    _orderItemcontext.SaveChanges();
                    Console.WriteLine("Added Order");
                }
                else if (Answer == "NO")
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine("Orders: ");
                    Console.ResetColor();
                    foreach (var item in _orderItemcontext.orderItems.Where(x => x.OrderID == order.Id).ToList())
                    {
                        Console.WriteLine(item);
                    }
                    MainLoop = false;
                }
                else
                {
                    Console.WriteLine("Answer could be YES or NO");
                }
            } while (MainLoop);
        }
        public void DeleteOrder(int id)
        {
            Order existingOrder = _Ordercontext.orders.SingleOrDefault(x => x.Id == id);
            if (existingOrder == null)
                throw new NotFoundException($"Not found order with {id} ID");
            _Ordercontext.orders.Remove(existingOrder);
            _Ordercontext.SaveChanges();
        }
        public void GetOrderWithDateInterval(DateTime startDate, DateTime endDate)
        {
            if (startDate > endDate)
                throw new WrongIntervalException("StartingDate can't be greater that EndingDate");
            var Orders = _Ordercontext.orders.Include(x => x.orderItems).Where(a => a.Date > startDate && a.Date < endDate)
           .Select(o => new
           {
               OrderId = o.Id,
               TotalAmount = o.TotalAmount,
               TotalMenuItems = o.orderItems.Sum(oi => oi.Count),
               OrderDate = o.Date
           }).ToList();
            if (Orders.Count == 0)
                throw new NotFoundException("Not found Order in this interval");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Orders: ");
            Console.ResetColor();
            foreach (var item in Orders)
            {
                Console.WriteLine($" - ID:{item.OrderId}, Total Amount:{item.TotalAmount}, Total Items:{item.TotalMenuItems}, Date:{item.OrderDate}");
            }
        }
        public async Task GetOrderWithDateIntervalAsync(DateTime startDate, DateTime endDate)
        {
            if (startDate > endDate)
                throw new WrongIntervalException("StartingDate can't be greater that EndingDate");
            var Orders = await _Ordercontext.orders.Include(x => x.orderItems).Where(a => a.Date >= startDate && a.Date <= endDate)
           .Select(o => new
           {
               OrderId = o.Id,
               TotalAmount = o.TotalAmount,
               TotalMenuItems = o.orderItems.Sum(oi => oi.Count),
               OrderDate = o.Date
           }).ToListAsync();
            if (Orders.Count == 0)
                throw new NotFoundException("Not found Order in this interval");
            foreach (var item in Orders)
            {
                Console.WriteLine($"ID:{item.OrderId}, Total Amount:{item.TotalAmount}, Total Items:{item.TotalMenuItems}, Date:{item.OrderDate}");
            }
        }
        public void GetOrdersWithDate(DateTime date)
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
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Orders: ");
            Console.ResetColor();
            foreach (var item in Orders)
            {
                Console.WriteLine($" - ID:{item.OrderId}, Total Amount:{item.TotalAmount}, Total Items:{item.TotalMenuItems}, Date:{item.OrderDate}");
            }
        }
        public async Task GetOrderWithDateAsync(DateTime date)
        {
            var Orders = await _Ordercontext.orders.Include(x => x.orderItems).Where(a => a.Date == date)
           .Select(o => new
           {
               OrderId = o.Id,
               TotalAmount = o.TotalAmount,
               TotalMenuItems = o.orderItems.Sum(oi => oi.Count),
               OrderDate = o.Date
           }).ToListAsync();
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
            var Orders = _Ordercontext.orders.Include(x => x.orderItems).Where(x => x.TotalAmount > minPrice && x.TotalAmount < maxPrice)
            .Select(o => new
            {
                OrderId = o.Id,
                TotalAmount = o.TotalAmount,
                TotalMenuItems = o.orderItems.Sum(oi => oi.Count),
                OrderDate = o.Date
            }).ToList();
            if (Orders.Count == 0)
                throw new NotFoundException("Not found Order in this interval");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Orders: ");
            Console.ResetColor();
            foreach (var item in Orders)
            {
                Console.WriteLine($" - ID:{item.OrderId}, Total Amount:{item.TotalAmount}, Total Items:{item.TotalMenuItems}, Date:{item.OrderDate}");
            }

        }
        public async Task GetOrderWithPriceIntervalAsync(double minPrice, double maxPrice)
        {
            if (minPrice > maxPrice)
                throw new ArgumentException("Min price can't be greater than max price");
            var Orders = await _Ordercontext.orders.Include(x => x.orderItems).Where(x => x.TotalAmount >= minPrice && x.TotalAmount <= maxPrice)
            .Select(o => new
            {
                OrderId = o.Id,
                TotalAmount = o.TotalAmount,
                TotalMenuItems = o.orderItems.Sum(oi => oi.Count),
                OrderDate = o.Date
            }).ToListAsync();
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
        public async Task<Order> GetOrderWithNoForOrderItemAsync(int id)
        {
            var Order = await _Ordercontext.orders.SingleOrDefaultAsync(x => x.Id == id);
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
                        ItemCount = o.orderItems.Where(o => o.MenuItemID == o.menuItem.Id).Count(),
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
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Order Item:");
            Console.ResetColor();
            foreach (var item in order.OrderItems)
            {
                Console.WriteLine($" - Item ID: {item.ItemId}, Name: {item.ItemName}, {item.ItemCount} ");
            }
        }
        public async Task GetOrderWithNoAsync(int id)
        {
            var order = await _Ordercontext.orders.Include(o => o.orderItems).ThenInclude(oi => oi.menuItem).Where(o => o.Id == id)
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
                        ItemCount = o.orderItems.Where(o => o.MenuItemID == o.menuItem.Id).Count(),
                    }).ToList()
                })
                .FirstOrDefaultAsync();
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
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Orders: ");
            Console.ResetColor();
            foreach (var item in Orders)
            {
                Console.WriteLine($" - ID:{item.OrderId}, Total Amount:{item.TotalAmount}, Total Items:{item.TotalMenuItems}, Date:{item.OrderDate}");
            }
        }
        public async Task GetAllOrdersAsync()
        {
            var Orders = await _Ordercontext.orders.Include(x => x.orderItems)
             .Select(o => new
             {
                 OrderId = o.Id,
                 TotalAmount = o.TotalAmount,
                 TotalMenuItems = o.orderItems.Sum(oi => oi.Count),
                 OrderDate = o.Date
             }).ToListAsync();
            if (Orders.Count() == 0)
                throw new ArgumentNullException("Do not found Order");
            foreach (var item in Orders)
            {
                Console.WriteLine($" - ID:{item.OrderId}, Total Amount:{item.TotalAmount}, Total Items:{item.TotalMenuItems}, Date:{item.OrderDate}");
            }
        }

    }
}
