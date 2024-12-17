namespace Restaurant.Core.Entities
{
    public class MenuItem : BaseEntity
    {
        public string Name { get; set; }
        public double? Price { get; set; } 
        public string Category { get; set; }
        public override string ToString()
        {
            return $" - ID:{Id}, Name:{Name}, Price:{Price}, Category:{Category}";
        }
    }
}
