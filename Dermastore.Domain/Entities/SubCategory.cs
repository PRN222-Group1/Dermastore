namespace Dermastore.Domain.Entities
{
    public class SubCategory : BaseEntity
    {
        public required string Name { get; set; }
        public string? Description { get; set; }
        public required int CategoryId { get; set; }
        public Category? Category { get; set; }
    }
}
