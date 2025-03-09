namespace Dermastore.Domain.Entities
{
    public class Answer : BaseEntity
    {
        public required string Content { get; set; }
        public List<Product> Products { get; set; }
        public int QuestionId { get; set; }
        public Question Question { get; set; }
    }
}
