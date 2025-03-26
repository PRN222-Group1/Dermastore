using Dermastore.Application.Extensions;
using Dermastore.Domain.Entities;
using Dermastore.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dermastore.Application.Commands.Questions
{
    public class CreateQuestionHandler : IRequestHandler<CreateQuestionCommand, int>
    {
        private readonly IGenericRepository<Question> _questionRepository;
        public CreateQuestionHandler(IGenericRepository<Question> questionRepository)
        {
            _questionRepository = questionRepository;     
        }
        public async Task<int> Handle(CreateQuestionCommand request, CancellationToken cancellationToken)
        {
            var question = new Question
            {
                Content = request.questionToAddDto.content,
                Answers = request.questionToAddDto.answers
            .Select(a => new Answer { Content = a.content })
            .ToList()
            };

            _questionRepository.Add(question);
            await _questionRepository.SaveAllAsync();

            return question.Id;
        }
    }
}
