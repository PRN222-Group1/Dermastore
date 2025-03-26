namespace Dermastore.Domain.Entities
{
    public class Answer : BaseEntity
    {
        public required string Content { get; set; }
        public List<Product> Products { get; set; }
        public int QuestionId { get; set; }
        public int QuizResultId {  get; set; }
        public Question Question { get; set; }
        public virtual QuizResult QuizResult { get; set; }
    }
}
