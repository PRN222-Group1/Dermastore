﻿using Dermastore.Application.DTOs;
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
                Price = product.Price,
                ImageUrl = product.ImageUrl,
                SubCategory = product.SubCategory?.Name,
                Brand = product.Brand?.Name,
                BrandId = product.BrandId,
                SubCategoryId = product.SubCategoryId,
                AnswerDTO = product.Answer?.ToDto(),
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
                SubCategoryId = productDto.SubCategoryId,
                AnswerId = productDto.AnswerId,
                BrandId = productDto.BrandId,
                Price = productDto.Price
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
            product.SubCategoryId = productDto.CategoryId;
            product.AnswerId = productDto.AnswerId;
        }

        public static ProductForQuizResultDto toProductQuizDto(this Product product)
        {
            if (product == null) throw new ArgumentNullException();
            return new ProductForQuizResultDto
            {
                answerId = product.AnswerId,
                description = product.Description,
                id = product.Id,
                imageUrl = product.ImageUrl,
                name = product.Name,
                quantity = product.Quantity,
                status = product.Status,
                price = product.Price,
            };
        }
    }
}
