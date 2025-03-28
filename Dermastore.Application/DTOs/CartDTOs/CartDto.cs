using Dermastore.Domain.Entities;

namespace Dermastore.Application.DTOs.CartDTOs
{
    public class CartDto
    {
        public string? Id { get; set; } = Guid.NewGuid().ToString();
        public List<CartItemDto> Items { get; set; } = [];
        public string? ClientSecret { get; set; }
        public string? PaymentIntentId { get; set; }
        public PromotionDto? Promotion { get; set; }
    }
}
