using Dermastore.Domain.Entities;
using Dermastore.Domain.Interfaces;
using Dermastore.Domain.Specifications.Products;
using MediatR;

namespace Dermastore.Application.Commands.Products
{
    public class DeleteProductHandler : IRequestHandler<DeleteProductCommand, bool>
    {
        private readonly IGenericRepository<Product> _productRepository;

        public DeleteProductHandler(IGenericRepository<Product> productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<bool> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            var spec = new ProductSpecification(request.Id);
            var product = await _productRepository.GetEntityWithSpec(spec);

            _productRepository.Delete(product);
            var result = await _productRepository.SaveAllAsync();

            return result;
        }
    }
}
