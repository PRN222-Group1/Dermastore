using Dermastore.Application.DTOs;
using Dermastore.Domain.Specifications.Products;
using MediatR;

namespace Dermastore.Application.Queries.Products
{
    public class GetProductsQuery : IRequest<IReadOnlyList<ProductDto>>
    {
        public ProductSpecParams ProductParams { get; set; }

        public GetProductsQuery(ProductSpecParams productSpecParams)
        {
            ProductParams = productSpecParams;
        }
    }
}
