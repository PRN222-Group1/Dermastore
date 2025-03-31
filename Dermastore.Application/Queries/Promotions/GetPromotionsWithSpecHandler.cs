using Dermastore.Application.DTOs;
using Dermastore.Application.Extensions;
using Dermastore.Domain.Entities;
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
    public class GetPromotionsWithSpecHandler : IRequestHandler<GetPromotionsWithSpecQuery, IReadOnlyList<PromotionDto>>
    {
        private readonly IPromotionService _promotionService;
        public GetPromotionsWithSpecHandler(IPromotionService promotionService)
        {
            _promotionService = promotionService;
        }
        public async Task<IReadOnlyList<PromotionDto>> Handle(GetPromotionsWithSpecQuery request, CancellationToken cancellationToken)
        {
            var spec = new PromotionSpecification(request.PromotionParams);
            var promotions = await _promotionService.GetPromotions(spec) ?? new List<Promotion>();
            return promotions.Select(p => p.ToDto()).ToList();
        }
    }
}
