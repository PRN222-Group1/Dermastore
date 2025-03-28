namespace Dermastore.Domain.Entities
{
    public class Question : BaseEntity
    {
        public required string Content { get; set; }
        public List<Answer> Answers { get; set; }
    }
}
