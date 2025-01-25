namespace Dermastore.Core.Entities
{
    public class Answer : BaseEntity
    {
        public required string Content { get; set; }
        public List<Product> Products { get; set; }
    }
}
