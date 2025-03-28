using Dermastore.Application.DTOs;
using Dermastore.Domain.Entities;
using Dermastore.Domain.Enums;

namespace Dermastore.Application.Extensions
{
    public static class PromotionMappingExtension
    {
        public static PromotionDto ToDto(this Promotion promotion)
        {
            if (promotion == null)
            {
                return null;
            }
            return new PromotionDto
            {
                Id = promotion.Id,
                Name = promotion.Name,
                Code = promotion.Code,
                Discount = promotion.Discount,
                EffectiveDate = promotion.EffectiveDate,
                ExpiryDate = promotion.ExpiryDate,
                Status = promotion.Status.ToString(),
            };
        }

        public static Promotion ToEntity(this PromotionDto promotion)
        {
            if (promotion == null)
            {
                return null;
            }
            return new Promotion
            {
                Id = promotion.Id,
                Name = promotion.Name,
                Code = promotion.Code,
                Discount = promotion.Discount,
                EffectiveDate = promotion.EffectiveDate,
                ExpiryDate = promotion.ExpiryDate,
                Status = (PromotionStatus) Enum.Parse(typeof(PromotionStatus), promotion.Status, true),
            };
        }
    }
}
