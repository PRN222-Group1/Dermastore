using Dermastore.Application.DTOs.QuestionDTOs;
using Dermastore.Application.Extensions;
using Dermastore.Domain.Entities;
using Dermastore.Domain.Interfaces;
using Dermastore.Domain.Specifications.Questions;
using MediatR;

namespace Dermastore.Application.Queries.Questions
{
    public class GetQuestionsHandler : IRequestHandler<GetQuestionsQuery, IReadOnlyList<QuestionDto>>
    {
        private readonly IGenericRepository<Question> _questionRepository;
        public GetQuestionsHandler(IGenericRepository<Question> genericRepository)
        {
            _questionRepository = genericRepository;
        }
        public async Task<IReadOnlyList<QuestionDto>> Handle(GetQuestionsQuery request, CancellationToken cancellationToken)
        {
            var spec  = new QuestionSpecification();
            var questions = await _questionRepository.ListAsync(spec);
            return questions.Select(q => q.ToDto()).ToList();
        }
    }
}
