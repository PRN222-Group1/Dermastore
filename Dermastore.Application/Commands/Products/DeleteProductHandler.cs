using Dermastore.Application.Interfaces;
using Dermastore.Domain.Entities;
using Dermastore.Domain.Interfaces;
using Dermastore.Domain.Specifications.Products;
using MediatR;

namespace Dermastore.Application.Commands.Products
{
    public class DeleteProductHandler : IRequestHandler<DeleteProductCommand, bool>
    {
        private readonly IProduct _iproduct;

        public DeleteProductHandler(IProduct iproduct)
        {
            _iproduct = iproduct;
        }

        public async Task<bool> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            bool result = await _iproduct.DeleteProduct(request.Id);
            return result;
        }
    }
}