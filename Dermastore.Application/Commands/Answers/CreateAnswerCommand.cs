using Dermastore.Application.DTOs.AnswerDTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dermastore.Application.Commands.Answers
{
    public class CreateAnswerCommand : IRequest<int>
    {
        public AnswerToAddDto AnswerDto { get; }

        public CreateAnswerCommand(AnswerToAddDto answerDto)
        {
            AnswerDto = answerDto;
        }
    }
}
