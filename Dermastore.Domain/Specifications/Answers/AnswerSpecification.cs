using Dermastore.Domain.Entities;

namespace Dermastore.Domain.Specifications.Answers
{
    public class AnswerSpecification : BaseSpecification<Answer>
    {
        public AnswerSpecification(Dictionary<int,int> answerIds) : base(a => answerIds.Values.Contains(a.Id))
        {
            AddInclude(a => a.QuizResult);
        }
        public AnswerSpecification()
        {
            AddInclude(a => a.Products);
        }
    }
}
