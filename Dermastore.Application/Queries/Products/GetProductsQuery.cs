using Dermastore.Application.DTOs;
using MediatR;

namespace Dermastore.Application.Queries.Products
{
    public class GetProductsQuery : IRequest<IReadOnlyList<ProductDto>>
    {
    }
}
