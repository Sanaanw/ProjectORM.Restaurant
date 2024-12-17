using Restaurant.Core.Entities;

namespace Restaurant.Service.Interfaces
{
    public interface IOrderService
    {
        void CreateOrder();
        void DeleteOrder(int id);
        void GetAllOrders();
        Task GetAllOrdersAsync();
        void GetOrdersWithDate(DateTime date);
        Task GetOrderWithDateAsync(DateTime date);
        void GetOrderWithDateInterval(DateTime startDate, DateTime endDate);
        Task GetOrderWithDateIntervalAsync(DateTime startDate, DateTime endDate);
        void GetOrderWithNo(int id);
        Task GetOrderWithNoAsync(int id);
        Order GetOrderWithNoForOrderItem(int id);
        Task<Order> GetOrderWithNoForOrderItemAsync(int id);
        void GetOrderWithPriceInterval(double minPrice, double maxPrice);
        Task GetOrderWithPriceIntervalAsync(double minPrice, double maxPrice);
        void UpdateOrder(int id, Order order);
        Task UpdateOrderAsync(int id, Order order);
    }
}