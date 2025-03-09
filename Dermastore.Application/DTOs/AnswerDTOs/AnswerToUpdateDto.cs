using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dermastore.Application.DTOs.AnswerDTOs
{
    public class AnswerToUpdateDto
    {
        public int answerId { get; set; }
        public string content { get; set; }
        public int questionId { get; set; }
    }
}
