namespace Restaurant.Core.Entities
{
    public class Order : BaseEntity
    {
        public double? TotalAmount { get; set; }
        public DateTime? Date { get; set; }
        List<OrderItem> orderItems;
    }
}
