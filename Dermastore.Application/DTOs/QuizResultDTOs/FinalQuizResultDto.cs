using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dermastore.Application.DTOs.QuizResultDTOs
{
    public class FinalQuizResultDto
    {
        public int resultId {  get; set; } 
        public List<int> answerIds { get; set; }
    }
}
