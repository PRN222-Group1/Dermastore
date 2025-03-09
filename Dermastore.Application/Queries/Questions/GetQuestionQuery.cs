using Dermastore.Application.DTOs.QuestionDTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dermastore.Application.Queries.Questions
{
    public class GetQuestionQuery : IRequest<QuestionDto>
    {
        public int id { get; set; }
        public GetQuestionQuery(int id)
        {
            this.id = id;
        }
    }
}
