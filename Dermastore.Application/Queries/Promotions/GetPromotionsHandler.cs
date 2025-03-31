using Dermastore.Application.DTOs;
using Dermastore.Application.Extensions;
using Dermastore.Domain.Entities;
using Dermastore.Domain.Interfaces;
using Dermastore.Domain.Specifications.Promotions;
using MediatR;

namespace Dermastore.Application.Queries.Promotions
{
    public class GetPromotionsHandler : IRequestHandler<GetPromotionsQuery, IReadOnlyList<PromotionDto>>
    {
        private readonly IGenericRepository<Promotion> _promotionRepo;

        public GetPromotionsHandler(IGenericRepository<Promotion> promotionRepo)
        {
            _promotionRepo = promotionRepo;
        }

        public async Task<IReadOnlyList<PromotionDto>> Handle(GetPromotionsQuery request, CancellationToken cancellationToken)
        {
            var spec = new PromotionSpecification();
            var promotions = await _promotionRepo.ListAsync(spec);
            return promotions.Select(p => p.ToDto()).ToList();
        }
    }
}
