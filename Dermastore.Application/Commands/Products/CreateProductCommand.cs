using Dermastore.Application.DTOs;
using Dermastore.Application.Interfaces;
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
