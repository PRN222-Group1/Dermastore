using Dermastore.Application.DTOs.QuizResultDTOs;
using MediatR;

namespace Dermastore.Application.Commands.QuizResults
{
    public class CreateQuizResultCommand : IRequest<int>
    {
        public QuizResultDto _quizResultDto { get; set; }
        public CreateQuizResultCommand(QuizResultDto quizResultDto)
        {
            _quizResultDto = quizResultDto;
        }
    }
}
