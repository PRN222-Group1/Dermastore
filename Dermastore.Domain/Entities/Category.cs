namespace Dermastore.Domain.Entities
{
    public class Category : BaseEntity
    {
        public required string Name { get; set; }
        public string? Description { get; set; }
        public List<SubCategory>? SubCategories { get; set; }
    }
}
