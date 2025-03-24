using Dermastore.Domain.Entities;
using Dermastore.Domain.Interfaces;
using MediatR;

namespace Dermastore.Application.Commands.Answers
{
    public class UpdateAnswerHandler : IRequestHandler<UpdateAnswerCommand, int>
    {
        private readonly IGenericRepository<Answer> _answerRepository;

        public UpdateAnswerHandler(IGenericRepository<Answer> answerRepository)
        {
            _answerRepository = answerRepository;
        }

        public async Task<int> Handle(UpdateAnswerCommand request, CancellationToken cancellationToken)
        {
            var answer = await _answerRepository.GetByIdAsync(request.AnswerDto.answerId);

            if (answer == null)
            {
                throw new Exception("Answer not found");
            }

            answer.Content = request.AnswerDto.content;
            answer.QuestionId = request.AnswerDto.questionId;
            answer.QuizResultId = request.AnswerDto.quizResultId;
            _answerRepository.Update(answer);
            await _answerRepository.SaveAllAsync();

            return answer.Id;
        }
    }
}
