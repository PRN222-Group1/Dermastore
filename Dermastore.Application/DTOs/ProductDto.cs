using Dermastore.Domain.Enums;

namespace Dermastore.Application.DTOs
{
    public class ProductDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public ProductStatus Status { get; set; }
        public int Quantity { get; set; } = 1;
        public decimal Price { get; set; }
        public string ImageUrl { get; set; }
        public int SubCategoryId { get; set; }
        public string? SubCategory { get; set; }
        public int BrandId { get; set; }
        public string? Brand{ get; set; }
    }
}
