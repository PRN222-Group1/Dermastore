using Dermastore.Application.DTOs;
using Dermastore.Domain.Entities;

namespace Dermastore.Application.Extensions
{
    public static class CategoryMappingExtension
    {
        public static CategoryDto ToDto(this Category category)
        {
            if (category == null) return null;

            return new CategoryDto
            {
                Id = category.Id,
                Name = category.Name,
                Description = category.Description,
                SubCategories = (category.SubCategories != null) 
                    ? category.SubCategories.Select(s => s.ToDto()) .ToList()
                    : new List<SubCategoryDto>()
            };
        }
    }
}
