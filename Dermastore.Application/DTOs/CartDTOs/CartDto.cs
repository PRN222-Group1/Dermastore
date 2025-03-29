using Dermastore.Domain.Entities;

namespace Dermastore.Application.DTOs.CartDTOs
{
    public class CartDto
    {
        public string? Id { get; set; } = Guid.NewGuid().ToString();
        public List<CartItemDto> Items { get; set; } = [];
        public PromotionDto? Promotion { get; set; }
        public DeliveryMethodDto? DeliveryMethod { get; set; }
    }
}
