using Dermastore.Application.DTOs.QuestionDTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dermastore.Application.Commands.Questions
{
    public class CreateQuestionCommand : IRequest<int>
    {
        public QuestionToAddDTO questionToAddDto { get; }
        public CreateQuestionCommand(QuestionToAddDTO questionToAddDto)
        {
            this.questionToAddDto = questionToAddDto;
        }
    }
}
