using Microsoft.Identity.Client;
using Restaurant.Core.Entities;
using Restaurant.DataAccess.Data;
using Restaurant.Service.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Service.Services
{
    public class OrderService
    {
        private readonly RestaurantContext _Ordercontext;
        public OrderService()
        {
            _Ordercontext = new RestaurantContext();
        }
        public void AddOrder(Order order)
        {
            if (_Ordercontext.orders.Any(x => x.Id == order.Id))
                throw new AlreadyExistsException("This order is already exists");
            _Ordercontext.orders.Add(order);
            _Ordercontext.SaveChanges();
        }
    }
}
