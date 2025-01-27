using Dermastore.Application.Extensions;
using Dermastore.Domain.Entities;
using Dermastore.Domain.Interfaces;
using MediatR;

namespace Dermastore.Application.Commands.Products
{
    public class CreateProductHandler : IRequestHandler<CreateProductCommand, int>
    {
        private readonly IGenericRepository<Product> _productRepository;

        public CreateProductHandler(IGenericRepository<Product> productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<int> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var product = request.ProductDto.ToEntity();
            product.AnswerId = 1;
            _productRepository.Add(product);
            await _productRepository.SaveAllAsync();

            return product.Id;
        }
    }
}

