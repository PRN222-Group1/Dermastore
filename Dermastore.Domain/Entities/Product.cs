using Dermastore.Domain.Enums;

namespace Dermastore.Domain.Entities
{
    public class Product : BaseEntity
    {
        public required string Name { get; set; }
        public required string Description { get; set; }
        public ProductStatus Status { get; set; } = ProductStatus.InStock;
        public int Quantity { get; set; } = 1;
        public required string ImageUrl { get; set; }
        public decimal Price {  get; set; }
        public int SubCategoryId { get; set; }
        public SubCategory SubCategory { get; set; }
        public int BrandId { get; set; }
        public Brand Brand { get; set; }
        public int AnswerId { get; set; }
        public Answer Answer { get; set; }
    }
}
