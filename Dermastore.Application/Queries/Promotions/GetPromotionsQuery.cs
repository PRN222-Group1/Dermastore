using Dermastore.Application.DTOs;
using MediatR;

namespace Dermastore.Application.Queries.Promotions
{
    public class GetPromotionsQuery : IRequest<IReadOnlyList<PromotionDto>>
    {
    }
}
