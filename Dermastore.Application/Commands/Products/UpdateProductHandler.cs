using Dermastore.Application.Extensions;
using Dermastore.Domain.Entities;
using Dermastore.Domain.Interfaces;
using Dermastore.Domain.Specifications.Products;
using MediatR;

namespace Dermastore.Application.Commands.Products
{
    public class UpdateProductHandler : IRequestHandler<UpdateProductCommand, int>
    {
        private readonly IGenericRepository<Product> _productRepository;

        public UpdateProductHandler(IGenericRepository<Product> productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<int> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            var spec = new ProductSpecification(request.ProductDto.Id);
            var product = await _productRepository.GetEntityWithSpec(spec);

            product.UpdateFromDto(request.ProductDto);
            product.AnswerId = 1;
            _productRepository.Update(product);
            await _productRepository.SaveAllAsync();

            return product.Id;
        }
    }
}
