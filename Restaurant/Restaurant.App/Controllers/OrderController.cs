using Restaurant.Core.Entities;
using Restaurant.Service.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.App.Controllers
{
    public class OrderController
    {
        private readonly OrderService _orderService;
        public OrderController()
        {
            _orderService = new OrderService();
        }
        public List<Order> Orders()
        {
            return _orderService.GetAllOrders();
        }
        public void CreateOrder(Order order)
        {
            _orderService.CreateOrder(order);
        }
        public List<Order> GetOrderByDatesInterval(DateTime _startDate, DateTime _endDate)
        {
            return _orderService.GetOrderWithDateInterval(_startDate, _endDate);
        }
        public List<Order> GetOrderByDate(DateTime _date)
        {
            return _orderService.GetOrderWithDate(_date);
        }
        public List<Order> GetOrderByPriceInterval(double? _minPrice, double? _maxPrice)
        {
            return _orderService.GetOrderWithPriceInterval(_minPrice,_maxPrice);
        }
        public Order GetOrderByNo(int _id)
        {
            return _orderService.GetOrderWithNo(_id);
        }
    }
}
