using Dermastore.Application.DTOs;
using MediatR;

namespace Dermastore.Application.Commands.Products
{
    public class UpdateProductCommand : IRequest<int>
    {
        public ProductToUpdateDto ProductDto { get; }

        public UpdateProductCommand(ProductToUpdateDto productDto)
        {
            ProductDto = productDto;
        }
    }
}
