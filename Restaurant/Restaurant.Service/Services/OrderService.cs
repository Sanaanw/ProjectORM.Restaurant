using Restaurant.DataAccess.Data;
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

    }
}
