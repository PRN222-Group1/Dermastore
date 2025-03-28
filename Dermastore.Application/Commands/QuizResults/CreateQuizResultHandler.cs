using Dermastore.Application.Commands.QuizResults;
using Dermastore.Application.Extensions;
using Dermastore.Domain.Entities;
using Dermastore.Domain.Interfaces;
using MediatR;

namespace Dermastore.Application.Commands.QuizResults
{
    public class CreateQuizResultHandler : IRequestHandler<CreateQuizResultCommand, int>
    {
        private readonly IGenericRepository<QuizResult> _quizResultRepository;
        public CreateQuizResultHandler(IGenericRepository<QuizResult> quizResultRepository)
        {
            _quizResultRepository = quizResultRepository;
        }
        public async Task<int> Handle(CreateQuizResultCommand request, CancellationToken cancellationToken)
        {
            var quizResultToUpdate = request._quizResultDto;
            QuizResult quizResult = quizResultToUpdate.ToEntity();
            
            if(quizResult == null)
            {
                return 0;
            }
            _quizResultRepository.Add(quizResult);
            await _quizResultRepository.SaveAllAsync();
            return quizResult.Id;
        }
    }
}
