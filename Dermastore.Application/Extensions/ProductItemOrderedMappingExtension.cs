using Dermastore.Application.DTOs.Orders;
using Dermastore.Application.DTOs;
using Dermastore.Domain.Entities.OrderAggregate;
using Dermastore.Domain.Entities;

namespace Dermastore.Application.Extensions
{
    public static class ProductItemOrderedMappingExtension
    {
        public static ProductItemOrderedDto ToDto(this ProductItemOrdered product)
        {
            if (product == null) return null;

            return new ProductItemOrderedDto
            {
                ImageUrl = product.ImageUrl,
                ProductName = product.ProductName,
                ProductId = product.ProductId,
            };
        }

        public static ProductItemOrdered ToEntity(this ProductItemOrderedDto productDto)
        {
            if (productDto == null) throw new ArgumentNullException(nameof(productDto));

            return new ProductItemOrdered
            {
                 ImageUrl = productDto.ImageUrl,
                 ProductName = productDto.ProductName,
                 ProductId = productDto.ProductId,
            };
        }
    }
}
