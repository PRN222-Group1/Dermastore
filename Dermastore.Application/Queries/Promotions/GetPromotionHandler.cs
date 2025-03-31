using Dermastore.Application.DTOs;
using Dermastore.Application.Extensions;
using Dermastore.Domain.Entities;
using Dermastore.Domain.Interfaces;
using Dermastore.Domain.Specifications.Promotions;
using MediatR;

namespace Dermastore.Application.Queries.Promotions
{
    public class GetPromotionHandler : IRequestHandler<GetPromotionQuery, PromotionDto>
    {
        private readonly IGenericRepository<Promotion> _promotionRepo;

        public GetPromotionHandler(IGenericRepository<Promotion> promotionRepo)
        {
            _promotionRepo = promotionRepo;
        }

        public async Task<PromotionDto> Handle(GetPromotionQuery request, CancellationToken cancellationToken)
        {
            var spec = new PromotionSpecification(request.Code);
            var promotion = await _promotionRepo.GetEntityWithSpec(spec);
            return promotion.ToDto();
        }
    }
}
