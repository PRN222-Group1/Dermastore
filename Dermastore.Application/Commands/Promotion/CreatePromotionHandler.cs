using Dermastore.Application.Extensions;
using Dermastore.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dermastore.Application.Commands.Promotion
{
    public class CreatePromotionHandler : IRequestHandler<CreatePromotionCommand, int>
    {
        private readonly IPromotionService _promotionService;

        public CreatePromotionHandler(IPromotionService promotionService)
        {
            _promotionService = promotionService;
        }

        public async Task<int> Handle(CreatePromotionCommand request, CancellationToken cancellationToken)
        {
            var promotion = request.PromotionDto.ToEntity();
            return await _promotionService.CreatePromotion(promotion);
        }
    }
}
