using Dermastore.Application.DTOs;
using Dermastore.Domain.Entities;

namespace Dermastore.Application.Extensions
{
    public static class SubCategoryMappingExtension
    {
        public static SubCategoryDto ToDto(this SubCategory subCategory)
        {
            if (subCategory == null) return null;

            return new SubCategoryDto
            {
                Id = subCategory.Id,
                Name = subCategory.Name,
                Description = subCategory.Description
            };
        }
    }
}
