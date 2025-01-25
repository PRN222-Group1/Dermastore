using Dermastore.Core.Enums;

namespace Dermastore.Core.Entities
{
    public class Promotion : BaseEntity
    {
        public required string Name { get; set; }
        public DateOnly EffectiveDate { get; set; }
        public DateOnly ExpiryDate { get; set; }
        public required decimal Discount { get; set; } = 0;
        public required string Code { get; set; }
        public PromotionStatus Status { get; set; } = PromotionStatus.Active;
    }
}
