using Dermastore.Domain.Enums;
using Dermastore.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dermastore.Application.Commands.Promotion
{
    public class UpdatePromotionHandler : IRequestHandler<UpdatePromotionCommand, int>
    {
        private readonly IPromotionService _promotionService;
        public UpdatePromotionHandler(IPromotionService promotionService)
        {
            _promotionService = promotionService;
        }

        public async Task<int> Handle(UpdatePromotionCommand request, CancellationToken cancellationToken)
        {
            var promotion = await _promotionService.GetPromotion(request.PromotionDto.Id);
            if (promotion == null) throw new Exception("Promotion not found");

            promotion.Name = request.PromotionDto.Name;
            promotion.EffectiveDate = request.PromotionDto.EffectiveDate;
            promotion.ExpiryDate = request.PromotionDto.ExpiryDate;
            promotion.Discount = request.PromotionDto.Discount;
            promotion.Code = request.PromotionDto.Code;
            if(Enum.TryParse<PromotionStatus>(request.PromotionDto.Status, true, out var status))
            {
                promotion.Status = status;
            }

            await _promotionService.EditPromotion(request.PromotionDto.Id, promotion);
            return promotion.Id;
        }
    }
}
