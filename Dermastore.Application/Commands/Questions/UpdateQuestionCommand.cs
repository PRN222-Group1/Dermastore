using Dermastore.Application.DTOs.QuestionDTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dermastore.Application.Commands.Questions
{
    public class UpdateQuestionCommand : IRequest<int>
    {
        public QuestionToUpdateDTO questionToUpdateDto { get; }
        public UpdateQuestionCommand(QuestionToUpdateDTO questionToUpdateDTO)
        {
            this.questionToUpdateDto = questionToUpdateDTO;
        }
    }
}
