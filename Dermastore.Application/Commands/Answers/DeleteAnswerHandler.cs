using Dermastore.Domain.Entities;
using Dermastore.Domain.Interfaces;
using MediatR;

namespace Dermastore.Application.Commands.Answers
{
    public class DeleteAnswerHandler : IRequestHandler<DeleteAnswerCommand, bool>
    {
        private readonly IGenericRepository<Answer> _answerRepository;

        public DeleteAnswerHandler(IGenericRepository<Answer> answerRepository)
        {
            _answerRepository = answerRepository;
        }

        public async Task<bool> Handle(DeleteAnswerCommand request, CancellationToken cancellationToken)
        {
            var answer = await _answerRepository.GetByIdAsync(request.Id);

            if (answer == null)
            {
                return false;
            }

            _answerRepository.Delete(answer);
            var result = await _answerRepository.SaveAllAsync();

            return result;
        }
    }
}
