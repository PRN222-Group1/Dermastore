using Dermastore.Application.DTOs;
using Dermastore.Domain.Entities;
using Dermastore.Domain.Interfaces;
using Dermastore.Domain.Specifications.Products;
using MediatR;

namespace Dermastore.Application.Queries.Products
{
    public class CountProductsHandler : IRequestHandler<CountProductsQuery, int>
    {
        private readonly IProductService _productService;

        public CountProductsHandler(IProductService productService)
        {
            _productService = productService;
        }

        public async Task<int> Handle(CountProductsQuery request, CancellationToken cancellationToken)
        {
            var spec = new ProductSpecification(request.ProductParams);
            var count = await _productService.CountProduct(spec);
            return count;
        }
    }
}
