using Dermastore.Application.DTOs;
using Dermastore.Application.Extensions;
using Dermastore.Domain.Entities;
using Dermastore.Domain.Interfaces;
using MediatR;

namespace Dermastore.Application.Commands.Products
{
    public class CreateProductHandler : IRequestHandler<CreateProductCommand, int>
    {
        public readonly IProductService _productService;

        public CreateProductHandler(IProductService productService)
        {
            _productService = productService ?? throw new ArgumentNullException(nameof(productService));
        }

        public async Task<int> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var product = request.ProductDto.ToEntity();

            Console.WriteLine("-------------------------");
            Console.WriteLine(product.Quantity);
            Console.WriteLine("-------------------------");
            if (request.ImageStream != null && !string.IsNullOrEmpty(request.FileExtension))
            {
                var fileName = $"{Guid.NewGuid()}{request.FileExtension}";
                product.ImageUrl = await _productService.UploadProductImage(request.ImageStream, fileName, true);
            }
            var rs = await _productService.CreateProduct(product);

            return product.Id;
        }
    }
}

