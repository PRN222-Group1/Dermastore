using Dermastore.Application.DTOs;
using Dermastore.Application.Extensions;
using Dermastore.Domain.Entities;
using Dermastore.Domain.Interfaces;
using Dermastore.Domain.Specifications.Products;
using MediatR;

namespace Dermastore.Application.Queries.Products
{
    public class GetProductHandler : IRequestHandler<GetProductQuery, ProductDto>
    {
        private readonly IGenericRepository<Product> _productRepository;

        public GetProductHandler(IGenericRepository<Product> productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<ProductDto> Handle(GetProductQuery request, CancellationToken cancellationToken)
        {
            var spec = new ProductSpecification(request.Id);
            var product = await _productRepository.GetEntityWithSpec(spec);
            return product.ToDto();
        }
    }
}
