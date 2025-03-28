using Dermastore.Application.DTOs;
using Dermastore.Domain.Specifications.Products;
using MediatR;

namespace Dermastore.Application.Queries.Products
{
    public class CountProductsQuery : IRequest<int>
    {
        public ProductSpecParams ProductParams { get; set; }

        public CountProductsQuery(ProductSpecParams productSpecParams)
        {
            ProductParams = productSpecParams;
        }
    }
}
