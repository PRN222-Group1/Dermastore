using Dermastore.Application.Extensions;
using Dermastore.Application.Interfaces;
using Dermastore.Domain.Entities;
using Dermastore.Domain.Interfaces;
using MediatR;

namespace Dermastore.Application.Commands.Products
{
    public class CreateProductHandler : IRequestHandler<CreateProductCommand, int>
    {
        private readonly IProduct _iproduct;

        public CreateProductHandler(IProduct iproduct)
        {
            _iproduct = iproduct;
        }

        public async Task<int> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            if (request.ProductDto == null)
            {
                throw new ArgumentNullException(nameof(request.ProductDto), "Product data is null");
            }

            bool result = await _iproduct.CreateProduct(request.ProductDto);
            return result ? 1 : 0;
        }
    }
}

