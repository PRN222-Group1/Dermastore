using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dermastore.Application.DTOs.AnswerDTOs
{
    public class AnswerDto
    {
        public int id { get;set; }
        public string content { get;set; }
        public int questionId { get; set; }
        public int quizResultId { get; set; }
        public List<ProductDto>? productDtos { get; set; }
    }
}
