using Dermastore.Application.DTOs;
using Dermastore.Domain.Entities;
using System.Net;

namespace Dermastore.Application.Extensions
{
    public static class ProductMappingExtension
    {
        public static ProductDto ToDto(this Product product)
        {
            if (product == null) return null;

            return new ProductDto
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                Status = product.Status,
                Quantity = product.Quantity,
                ImageUrl = product.ImageUrl,
                CategoryId = product.CategoryId,
                Category = product.Category.Name
            };
        }

        public static Product ToEntity(this ProductToAddDto productDto)
        {
            if (productDto == null) throw new ArgumentNullException(nameof(productDto));

            return new Product
            {
                Name = productDto.Name,
                Description = productDto.Description,
                Status = productDto.Status,
                Quantity = productDto.Quantity,
                ImageUrl = productDto.ImageUrl,
                CategoryId = productDto.CategoryId,
                AnswerId = productDto.AnswerId,
            };
        }

        public static void UpdateFromDto(this Product product, ProductToUpdateDto productDto)
        {
            if (productDto == null) throw new ArgumentNullException(nameof(productDto));
            if (product == null) throw new ArgumentNullException(nameof(product));

            product.Name = productDto.Name;
            product.Description = productDto.Description;
            product.Status = productDto.Status;
            product.Quantity = productDto.Quantity;
            product.ImageUrl = productDto.ImageUrl;
            product.CategoryId = productDto.CategoryId;
            product.AnswerId = productDto.AnswerId;
        }
    }
}
