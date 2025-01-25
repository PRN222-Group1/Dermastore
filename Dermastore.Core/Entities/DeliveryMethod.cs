namespace Dermastore.Core.Entities
{
    public class DeliveryMethod : BaseEntity
    {
        public required string Name { get; set; }
        public required string DeliveryTime { get; set; }
        public required string Description { get; set; }
        public decimal Price { get; set; }
    }
}
