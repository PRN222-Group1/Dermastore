using Dermastore.Application.DTOs.QuizResultDTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dermastore.Application.Commands.QuizResults
{
    public class DetermineQuizResultCommand : IRequest<FinalQuizResultDto>
    {
        public Dictionary<int, int> answers { get; }
        public DetermineQuizResultCommand(Dictionary<int, int> answers)
        {
            this.answers = answers;
        }
    }
}
