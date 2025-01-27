using Dermastore.Application.DTOs;
using MediatR;

namespace Dermastore.Application.Commands.Products
{
    public class CreateProductCommand : IRequest<int>
    {
        public ProductToAddDto ProductDto { get; }

        public CreateProductCommand(ProductToAddDto productDto) 
        {
            ProductDto = productDto;
        }
    }
}
