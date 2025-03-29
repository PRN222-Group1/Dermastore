using Dermastore.Application.Extensions;
using Dermastore.Domain.Entities;
using Dermastore.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dermastore.Application.Commands.QuizResults
{
    public class UpdateQuizResultHandler : IRequestHandler<UpdateQuizResultCommand, int>
    {
        private readonly IGenericRepository<QuizResult> quizResultRepository;
        public UpdateQuizResultHandler(IGenericRepository<QuizResult> quizResultRepository)
        {
            this.quizResultRepository = quizResultRepository;
        }
        public async Task<int> Handle(UpdateQuizResultCommand request, CancellationToken cancellationToken)
        {
            if(request == null)
            {
                return 0;
            }
            var quizResult = await quizResultRepository.GetByIdAsync(request.updateQuizResultDto.quizId);
            if(quizResult == null)
            {
                throw new Exception("Can't find quiz result with id: " + request.updateQuizResultDto.quizId);
            }
            quizResult.UpdateQuizResultFromDto(request.updateQuizResultDto);
            await quizResultRepository.SaveAllAsync();
            return quizResult.Id;
        }
    }
}
