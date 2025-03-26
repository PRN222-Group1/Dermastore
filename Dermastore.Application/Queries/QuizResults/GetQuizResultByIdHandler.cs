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
    public class GetQuizResultByIdHandler : IRequestHandler<GetQuizResultByIdQueury, QuizResultResponseDto>
    {
        private readonly IGenericRepository<QuizResult> quizResultRepository;

        public GetQuizResultByIdHandler(IGenericRepository<QuizResult> quizResultRepository)
        {
            this.quizResultRepository = quizResultRepository;
        }
        public async Task<QuizResultResponseDto?> Handle(GetQuizResultByIdQueury request, CancellationToken cancellationToken)
        {
            var spec = new QuizResultSpecification(request.quizId);
            var quizResult = await quizResultRepository.GetEntityWithSpec(spec);
            if (quizResult == null)
            {
                return null;
            }
            return quizResult.ToDto();
        }
    }
}
