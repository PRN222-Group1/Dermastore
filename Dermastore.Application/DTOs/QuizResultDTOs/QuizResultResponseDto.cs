using Dermastore.Application.DTOs.AnswerDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dermastore.Application.DTOs.QuizResultDTOs
{
    public class QuizResultResponseDto
    {
        public int quizId { get; set; }
        public string skinType { get; set; }
        public string description { get; set; }
        public string characteristic { get; set; }
        public string careTips { get; set; }
        public IReadOnlyList<AnswerDto?>? answerDTOs { get; set; }
    }
}
