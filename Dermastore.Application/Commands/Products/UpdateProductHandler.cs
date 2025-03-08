using Dermastore.Application.Extensions;
using Dermastore.Application.Interfaces;
using Dermastore.Domain.Entities;
using Dermastore.Domain.Interfaces;
using Dermastore.Domain.Specifications.Products;
using MediatR;

namespace Dermastore.Application.Commands.Products
{
    public class UpdateProductHandler : IRequestHandler<UpdateProductCommand, int>
    {
        private readonly IProduct _iproduct;

        public UpdateProductHandler(IProduct iproduct)
        {
            _iproduct = iproduct;
        }

        public async Task<int> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            var update = await _iproduct.EditProduct(request.ProductDto.Id, request.ProductDto);
            return update ? 1 : 0;
        }
    }
}