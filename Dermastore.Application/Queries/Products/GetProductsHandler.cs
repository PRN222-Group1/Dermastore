using Dermastore.Application.DTOs;
using Dermastore.Application.Extensions;
using Dermastore.Domain.Entities;
using Dermastore.Domain.Interfaces;
using Dermastore.Domain.Specifications.Products;
using MediatR;

namespace Dermastore.Application.Queries.Products
{
    public class GetProductsHandler : IRequestHandler<GetProductsQuery, IReadOnlyList<ProductDto>>
    {
        private readonly IGenericRepository<Product> _productRepository;

        public GetProductsHandler(IGenericRepository<Product> productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<IReadOnlyList<ProductDto>> Handle(GetProductsQuery request, CancellationToken cancellationToken)
        {
            if (_productRepository == null)
            {
                throw new InvalidOperationException("ProductRepository is not initialized.");
            }

            var spec = new ProductSpecification();
            var products = await _productRepository.ListAsync(spec) ?? new List<Product>();

            var productsToReturn = products.Select(p => p.ToDto()).ToList();
            return productsToReturn;
        }
    }
}
