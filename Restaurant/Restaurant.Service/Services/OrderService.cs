using Restaurant.Core.Entities;
using Restaurant.DataAccess.Data;
using Restaurant.Service.Exceptions;

namespace Restaurant.Service.Services
{
    public class OrderService
    {
        private readonly RestaurantContext _Ordercontext;
        public OrderService()
        {
            _Ordercontext = new RestaurantContext();
        }
        public void CreateOrder(Order order)
        {
            if (_Ordercontext.orders.Any(x => x.Id == order.Id))
                throw new AlreadyExistsException($"The order with {order.Id} ID is already exist");
            _Ordercontext.orders.Add(order);
            _Ordercontext.SaveChanges();
        }
        public List<Order> GetOrderWithDateInterval(DateTime startDate, DateTime endDate)
        {
            if (startDate > endDate)
                throw new WrongIntervalException("StartinDate can't be greater that EndingDate");
            var Orders = _Ordercontext.orders.Where(x => x.Date >= startDate && x.Date <= endDate).ToList();
            if (Orders is null)
                throw new NotFoundException("Not found Order in this interval");
            return Orders;
        }
        public List<Order> GetOrderWithDate(DateTime date)
        {
            var Orders = _Ordercontext.orders.Where(x => x.Date == date).ToList();
            if (Orders is null)
                throw new NotFoundException("Not found Order in this Date");
            return Orders;
        }
        public List<Order> GetOrderWithPriceInterval(double? minPrice, double? maxPrice)
        {
            if (minPrice.HasValue && maxPrice.HasValue)
                throw new ArgumentNullException("Price can't be null");
            if (minPrice > maxPrice)
                throw new ArgumentException("Min price can't be greater than max price");
            var Orders = _Ordercontext.orders.Where(x => x.TotalAmount >= minPrice && x.TotalAmount <= maxPrice).ToList();
            if (Orders is null)
                throw new NotFoundException("Not found Order in this interval");
            return Orders;
        }
        public Order GetOrderWithNo(int id)
        {
            var Order = _Ordercontext.orders.SingleOrDefault(x => x.Id == id);
            if (Order is null)
                throw new NotFoundException("Not found Order in this No");
            return Order;
        }
    }
}
