using Dermastore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dermastore.Domain.Specifications.QuizResults
{
    public class QuizResultSpecification : BaseSpecification<QuizResult>
    {
        public QuizResultSpecification(int id) :base(x => x.Id == id)
        {
            AddInclude(x => x.Answers);
        }
        public QuizResultSpecification()
        {
            
        }
    }
}
