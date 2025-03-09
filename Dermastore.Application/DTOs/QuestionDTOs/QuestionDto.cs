using Dermastore.Application.DTOs.AnswerDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dermastore.Application.DTOs.QuestionDTOs
{
    public class QuestionDto
    {
        public int id { get; set; }
        public string content { get; set; }
        public List<AnswerDto> answers { get; set; }
    }
}
