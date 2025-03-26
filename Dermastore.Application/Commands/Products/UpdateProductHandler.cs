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

                var spec = new ProductSpecification(request.ProductDto.Id);


            if (_productService == null)
                {
                    throw new InvalidOperationException("ProductService is not initialized.");
                }

                Product product = await _productService.GetProduct(request.ProductDto.Id);

                // Gán dữ liệu từ DTO vào Product
                product.Name = request.ProductDto.Name;
                product.Description = request.ProductDto.Description;
                product.Status = request.ProductDto.Status;
                product.Quantity = request.ProductDto.Quantity;
                product.ImageUrl = request.ProductDto.ImageUrl;
                product.SubCategoryId = request.ProductDto.CategoryId;

                // Gọi hàm EditProduct
                bool updateResult = await _productService.EditProduct(request.ProductDto.Id, product);


                if (!updateResult)
                {
                    throw new Exception("Failed to update product.");
                }

                return product.Id;
            }

    }
}
