using Dermastore.Application.DTOs;
using MediatR;

namespace Dermastore.Application.Commands.Products
{
    public class UpdateProductCommand : IRequest<int>
    {
        public ProductToUpdateDto ProductDto { get; set; }
        public Stream ImageStream { get; set; }
        public string FileExtension { get; set; }

        public UpdateProductCommand(ProductToUpdateDto productDto, Stream imageStream = null, string fileExtension = null)
        {
            ProductDto = productDto;
            ImageStream = imageStream;
            FileExtension = fileExtension;
        }
    }
}
