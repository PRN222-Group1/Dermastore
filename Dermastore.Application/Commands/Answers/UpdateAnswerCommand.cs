using Dermastore.Application.DTOs.AnswerDTOs;
using MediatR;

namespace Dermastore.Application.Commands.Answers
{
    public class UpdateAnswerCommand : IRequest<int>
    {
        public AnswerToUpdateDto AnswerDto { get; }

        public UpdateAnswerCommand(AnswerToUpdateDto answerDto)
        {
            AnswerDto = answerDto;
        }
    }
}
