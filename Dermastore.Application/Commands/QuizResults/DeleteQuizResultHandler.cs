using Dermastore.Domain.Entities;
using Dermastore.Domain.Interfaces;
using Dermastore.Domain.Specifications.QuizResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dermastore.Application.Commands.QuizResults
{
    public class DeleteQuizResultHandler : IRequestHandler<DeleteQuizResultCommand, bool>
    {
        private readonly IGenericRepository<QuizResult> _quizResultRepository;
        public DeleteQuizResultHandler(IGenericRepository<QuizResult> quizResultRepository)
        {
            _quizResultRepository = quizResultRepository;
        }
        public async Task<bool> Handle(DeleteQuizResultCommand request, CancellationToken cancellationToken)
        {
            var spec = new QuizResultSpecification(request.id);
            var answerToDelete = await _quizResultRepository.GetEntityWithSpec(spec);
            if (answerToDelete == null)
            {
                return false;
            }
            answerToDelete.Answers.ToList().ForEach(a => a.QuizResultId = 0);
            _quizResultRepository.Delete(answerToDelete);
            return await _quizResultRepository.SaveAllAsync();
        }
    }
}
