using Dermastore.Core.Enums;

namespace Dermastore.Core.Entities
{
    public class Product : BaseEntity
    {
        public required string Name { get; set; }
        public required string Description { get; set; }
        public ProductStatus Status { get; set; } = ProductStatus.InStock;
        public int Quantity { get; set; } = 1;
        public required string ImageUrl { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public int AnswerId { get; set; }
        public Answer Answer { get; set; }
    }
}
