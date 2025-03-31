using Dermastore.Domain.Enums;

namespace Dermastore.Application.DTOs
{
    public class ProductToAddDto
    {
        public string Name { get; set; } = "";
        public string Description { get; set; } = "";
        public ProductStatus Status { get; set; } = ProductStatus.InStock;
        public int Quantity { get; set; } = 1;
        public string ImageUrl { get; set; }
        public int CategoryId { get; set; }
        public int AnswerId { get; set; }
        public int SubCategoryId { get; set; }
        public int BrandId { get; set; }
        public decimal Price { get; set; }
    }
}
