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
        public void ShowAllOrders()
        {
            _orderService.GetAllOrders();
        }

        public void CreateOrder(Order order)
        {
            _orderService.CreateOrder(order);
        }
        public void GetOrderByDateInterval(DateTime _startDate, DateTime _endDate)
        {
            _orderService.GetOrderWithDateInterval(_startDate, _endDate);
        }
        public void ShowOrdersForGivenDate(DateTime _date)
        {
            _orderService.GetOrderWithDate(_date);
        }
        public void ShowOrderByAmountRange(double _minPrice, double _maxPrice)
        {
             _orderService.GetOrderWithPriceInterval(_minPrice,_maxPrice);
        }
        public void GetOrderByNo(int _id)
        {
          _orderService.GetOrderWithNo(_id);
        }
    }
}
