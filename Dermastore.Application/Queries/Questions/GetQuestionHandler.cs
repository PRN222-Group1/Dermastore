using Dermastore.Application.DTOs.QuestionDTOs;
using Dermastore.Application.Extensions;
using Dermastore.Domain.Entities;
using Dermastore.Domain.Interfaces;
using Dermastore.Domain.Specifications.Questions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dermastore.Application.Queries.Questions
{
    public class GetQuestionHandler : IRequestHandler<GetQuestionQuery, QuestionDto>
    {
        private readonly IGenericRepository<Question> _questionRepository;
        public GetQuestionHandler(IGenericRepository<Question> questionRepository)
        {
            _questionRepository = questionRepository;
        }
        public async Task<QuestionDto> Handle(GetQuestionQuery request, CancellationToken cancellationToken)
        {
            var spec = new QuestionSpecification(request.id);
            var question = await _questionRepository.GetEntityWithSpec(spec);
            return question.ToDto();
        }
    }
}
