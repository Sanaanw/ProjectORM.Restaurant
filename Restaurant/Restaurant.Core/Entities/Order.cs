namespace Restaurant.Core.Entities
{
    public class Order : BaseEntity
    {
        public double? TotalAmount { get; set; }
        public DateTime? Date { get; set; }
        public List<OrderItem> orderItems { get; set; }
        public override string ToString()
        {
            return $"ID:{Id}, TotalAmount:{TotalAmount}, Date:{Date}, ";
        }
    }
}
