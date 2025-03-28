using Dermastore.Domain.Enums;

namespace Dermastore.Application.DTOs
{
    public class PromotionDto
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public DateOnly EffectiveDate { get; set; }
        public DateOnly ExpiryDate { get; set; }
        public decimal Discount { get; set; } = 0;
        public string? Code { get; set; }
        public string? Status { get; set; }
    }
}
