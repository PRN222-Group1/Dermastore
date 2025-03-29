using Dermastore.Application.DTOs.QuizResultDTOs;
using Dermastore.Application.Extensions;
using Dermastore.Domain.Entities;
using Dermastore.Domain.Interfaces;
using Dermastore.Domain.Specifications.QuizResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dermastore.Application.Queries.QuizResults
{
    public class GetAllQuizResultHandler : IRequestHandler<GetAllQuizResultQueury, IReadOnlyList<QuizResultResponseDto>>
    {
        private readonly IGenericRepository<QuizResult> quizResultRepository;
        public GetAllQuizResultHandler(IGenericRepository<QuizResult> quizResultRepository)
        {
            this.quizResultRepository = quizResultRepository;
        }
        public async Task<IReadOnlyList<QuizResultResponseDto>> Handle(GetAllQuizResultQueury request, CancellationToken cancellationToken)
        {
            var spec = new QuizResultSpecification();
            var result = await quizResultRepository.ListAsync(spec);
            var response = result.Select(x => x.ToDto()).ToList();
            return response;
        }
    }
}
