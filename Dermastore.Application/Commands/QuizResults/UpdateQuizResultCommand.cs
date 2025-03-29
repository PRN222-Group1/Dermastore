using Dermastore.Application.DTOs.QuizResultDTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dermastore.Application.Commands.QuizResults
{
    public class UpdateQuizResultCommand : IRequest<int>
    {
        public UpdateQuizResultDto updateQuizResultDto { get; }
        public UpdateQuizResultCommand(UpdateQuizResultDto updateQuizResultDto)
        {
            this.updateQuizResultDto = updateQuizResultDto;
        }
    }
}
