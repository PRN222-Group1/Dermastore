using Dermastore.Application.DTOs;
using MediatR;

namespace Dermastore.Application.Queries.Dashboard
{
    public class GetMostSoldProductQuery : IRequest<Dictionary<ProductDto, int>?>
    {
    }
}
