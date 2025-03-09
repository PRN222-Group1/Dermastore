using Dermastore.Domain.Entities;
using Dermastore.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dermastore.Application.Commands.Answers
{
    public class CreateAnswerHandler : IRequestHandler<CreateAnswerCommand, int>
    {
        private readonly IGenericRepository<Answer> _answerRepository;

        public CreateAnswerHandler(IGenericRepository<Answer> answerRepository)
        {
            _answerRepository = answerRepository;
        }

        public async Task<int> Handle(CreateAnswerCommand request, CancellationToken cancellationToken)
        {
            var answer = new Answer
            {
                Content = request.AnswerDto.content,
                QuestionId = request.AnswerDto.questionId
            };

            _answerRepository.Add(answer);
            await _answerRepository.SaveAllAsync();

            return answer.Id;
        }
    }
}
