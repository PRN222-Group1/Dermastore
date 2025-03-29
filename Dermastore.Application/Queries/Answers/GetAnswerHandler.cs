using Dermastore.Application.DTOs.AnswerDTOs;
using Dermastore.Application.Extensions;
using Dermastore.Domain.Entities;
using Dermastore.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dermastore.Application.Queries.Answers
{
    public class GetAnswerHandler : IRequestHandler<GetAnswerQuery, AnswerDto>
    {
        private readonly IGenericRepository<Answer> _answerRepository;
        public GetAnswerHandler(IGenericRepository<Answer> answerRepository)
        {
            _answerRepository = answerRepository;
        }
        public async Task<AnswerDto> Handle(GetAnswerQuery request, CancellationToken cancellationToken)
        {
            var answer = await _answerRepository.GetByIdAsync(request.Id);

            if (answer == null)
            {
                return null;
            }

            return answer.ToDto();
        }
    }
}
