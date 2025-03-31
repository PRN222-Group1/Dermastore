using Dermastore.Application.DTOs;
using MediatR;

namespace Dermastore.Application.Commands.Products
{
    public class CreateProductCommand : IRequest<int>
    {
        public ProductToAddDto ProductDto { get; set; }
        public Stream ImageStream { get; set; }
        public string FileExtension { get; set; }

        public CreateProductCommand(ProductToAddDto productDto, Stream imageStream = null, string fileExtension = null)
        {
            ProductDto = productDto;
            ImageStream = imageStream;
            FileExtension = fileExtension;
        }
    }
}
