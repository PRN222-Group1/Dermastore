using Dermastore.Application.DTOs.AnswerDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dermastore.Application.DTOs.QuestionDTOs
{
    public class QuestionToAddDTO
    {
        public string content { get; set; }
        public List<AnswerToAddDto> answers { get; set; } = new();
    }
}
