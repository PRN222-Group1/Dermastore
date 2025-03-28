using Dermastore.Domain.Entities;
using Dermastore.Domain.Interfaces;
using Dermastore.Domain.Specifications.Questions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dermastore.Application.Commands.Questions
{
    public class UpdateQuestionHandler : IRequestHandler<UpdateQuestionCommand, int>
    {
        private readonly IGenericRepository<Question> _questionRepository;
        public UpdateQuestionHandler(IGenericRepository<Question> questionRepository)
        {
            _questionRepository = questionRepository;
        }
        public async Task<int> Handle(UpdateQuestionCommand request, CancellationToken cancellationToken)
        {
            var spec = new QuestionSpecification(request.questionToUpdateDto.questionId);
            var question = await _questionRepository.GetEntityWithSpec(spec);
            question.Content = request.questionToUpdateDto.content;
            _questionRepository.Update(question);
            await _questionRepository.SaveAllAsync();
            return request.questionToUpdateDto.questionId;
        }
    }
}
