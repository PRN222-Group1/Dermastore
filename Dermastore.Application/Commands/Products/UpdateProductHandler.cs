using Dermastore.Application.Extensions;
using Dermastore.Domain.Entities;
using Dermastore.Domain.Interfaces;
using Dermastore.Domain.Specifications.Products;
using MediatR;

namespace Dermastore.Application.Commands.Products
{
    public class UpdateProductHandler : IRequestHandler<UpdateProductCommand, int>
    {

        public readonly IProductService _productService;

        public UpdateProductHandler(IProductService productService)
        {
            _productService = productService ?? throw new ArgumentNullException(nameof(productService));
        }

        public async Task<int> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            if (request.ProductDto == null)
            {
                throw new ArgumentNullException(nameof(request.ProductDto), "ProductDto is null");
            }

            var product = await _productService.GetProduct(request.ProductDto.Id);
            if (product == null)
            {
                throw new Exception($"Product with ID {request.ProductDto.Id} not found.");
            }

            // Update product properties
            product.Name = request.ProductDto.Name;
            product.Description = request.ProductDto.Description;
            product.Quantity = request.ProductDto.Quantity;
            product.ImageUrl = request.ProductDto.ImageUrl;
            product.SubCategoryId = request.ProductDto.SubCategoryId;
            product.BrandId = request.ProductDto.BrandId;
            product.Quantity = request.ProductDto.Quantity;
            product.Price = request.ProductDto.Price;

            // Handle image upload if provided
            if (request.ImageStream != null && !string.IsNullOrEmpty(request.FileExtension))
            {
                var oldFileName = Path.GetFileName(new Uri(product.ImageUrl).LocalPath);
                product.ImageUrl = await _productService.UploadProductImage(request.ImageStream, oldFileName, false);
            }

            bool updateResult = await _productService.EditProduct(request.ProductDto.Id, product);
            if (!updateResult)
            {
                throw new Exception("Failed to update product.");
            }

            return product.Id;
        }

    }
}
