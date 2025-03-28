using Dermastore.Application.DTOs.QuizResultDTOs;
using Dermastore.Application.Extensions;
using Dermastore.Domain.Entities;
using Dermastore.Domain.Interfaces;
using Dermastore.Domain.Specifications.Answers;
using Dermastore.Domain.Specifications.QuizResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Dermastore.Application.Commands.QuizResults
{
    public class DetermineQuizResultHandler : IRequestHandler<DetermineQuizResultCommand, FinalQuizResultDto>
    {
        private readonly IGenericRepository<QuizResult> quizResultRepository;
        private readonly IGenericRepository<Answer> answerRepository;
        public DetermineQuizResultHandler(IGenericRepository<QuizResult> quizResultRepository, IGenericRepository<Answer> answerRepository)
        {
            this.quizResultRepository = quizResultRepository;
            this.answerRepository = answerRepository;
        }
        public async Task<FinalQuizResultDto> Handle(DetermineQuizResultCommand request, CancellationToken cancellationToken)
        {
            var answerResultIds = request.answers;
            var answerSpec = new AnswerSpecification(answerResultIds);
            var answers = await answerRepository.ListAsync(answerSpec);
            var answerList = new List<Answer>();
            answerList = answerResultIds.Values.Select(id => answers.FirstOrDefault(a => a.Id == id)).Where(a => a!=null).ToList();

            var groupedResults = answerList.GroupBy(a => a.QuizResultId).Select(g => new { quizResultId = g.Key, frequency = g.Count()}).ToList();

            if (!groupedResults.Any())
            {
                throw new Exception("No valid answers found to determine the quiz result.");
            }

            var maxFrequency = groupedResults.Max(g => g.frequency);
            var highestResult = groupedResults.Where(g => g.frequency == maxFrequency).ToList();
            int finalResult;
            if(highestResult.Count == 1)
            {
                finalResult = highestResult.First().quizResultId;
            } else
            {
                finalResult = 5;
            }

            var finalResultDto = new FinalQuizResultDto
            {
                resultId = finalResult,
                answerIds = answerList.Where(a => highestResult.Select(h => h.quizResultId).Contains(a.QuizResultId)).Select(a => a.Id).ToList(),
            };
            return finalResultDto;
        }
    }
}
