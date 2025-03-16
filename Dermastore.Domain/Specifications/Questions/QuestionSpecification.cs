using Dermastore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dermastore.Domain.Specifications.Questions
{
    public class QuestionSpecification : BaseSpecification<Question>
    {
        public QuestionSpecification()
        {
            AddInclude(q => q.Answers);
        }
        public QuestionSpecification(int id) : base(x => x.Id == id)
        {
            AddInclude(q => q.Answers);
        }
    }
}
