using Dermastore.Domain.Interfaces;
using Dermastore.Domain.Specifications.Promotions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dermastore.Application.Queries.Promotions
{
    public class CountPromotionsHandler : IRequestHandler<CountPromotionsQuery, int>
    {
        private readonly IPromotionService _promotionService;

        public CountPromotionsHandler(IPromotionService promotionService)
        {
            _promotionService = promotionService;
        }

        public async Task<int> Handle(CountPromotionsQuery request, CancellationToken cancellationToken)
        {
            var spec = new PromotionSpecification(request.PromotionParams);
            return await _promotionService.CountPromotion(spec);
        }
    }
}
