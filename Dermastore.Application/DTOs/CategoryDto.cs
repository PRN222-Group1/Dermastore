﻿namespace Dermastore.Application.DTOs
{
    public class CategoryDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public IReadOnlyList<SubCategoryDto> SubCategories { get; set; }
    }
}
