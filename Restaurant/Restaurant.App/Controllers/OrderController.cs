using Restaurant.Core.Entities;
using Restaurant.Service.Services;

namespace Restaurant.App.Controllers
{
    public class OrderController
    {
        private readonly OrderService _orderService;
        public OrderController()
        {
            _orderService = new OrderService();
        }
        public void CreateOrder()
        {
            _orderService.CreateOrder();
        }
        public void RemoveOrder(int _id)
        {
            _orderService.DeleteOrder(_id);
            Console.WriteLine($"Deleted order with {_id} ID");
        }
        public void ShowAllOrders()
        {
            _orderService.GetAllOrders();
        }
        public void GetOrderByDateInterval(DateTime _startDate, DateTime _endDate)
        {
            _orderService.GetOrderWithDateInterval(_startDate, _endDate);
        }
        public void ShowOrdersForGivenDate(DateTime _date)
        {
            _orderService.GetOrdersWithDate(_date);
        }
        public void ShowOrderByAmountRange(double _minPrice, double _maxPrice)
        {
            _orderService.GetOrderWithPriceInterval(_minPrice, _maxPrice);
        }
        public void GetOrderByNo(int _id)
        {
            _orderService.GetOrderWithNo(_id);
        }
    }
}
