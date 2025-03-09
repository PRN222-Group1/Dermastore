using Dermastore.Application.DTOs.AnswerDTOs;
using Dermastore.Domain.Interfaces;
using MediatR;
using Dermastore.Domain.Entities;

namespace Dermastore.Application.Queries.Answers
{
    public class GetAllAnswersHandler : IRequestHandler<GetAllAnswersQuery, IReadOnlyList<AnswerDto>>
    {
        private readonly IGenericRepository<Answer> _answerRepository;

        public GetAllAnswersHandler(IGenericRepository<Answer> answerRepository)
        {
            _answerRepository = answerRepository;
        }

        public async Task<IReadOnlyList<AnswerDto>> Handle(GetAllAnswersQuery request, CancellationToken cancellationToken)
        {
            var answers = await _answerRepository.ListAllAsync();
            return answers.Select(a => new AnswerDto
            {
                id = a.Id,
                content = a.Content,
                questionId = a.QuestionId
            }).ToList();
        }
    }
}
