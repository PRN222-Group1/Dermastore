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
        public string ImageUrl { get; set; }
        public int CategoryId { get; set; }
        public string? Category { get; set; }
    }
}
