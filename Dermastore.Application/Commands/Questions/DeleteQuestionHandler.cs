using Dermastore.Domain.Entities;
using Dermastore.Domain.Interfaces;
using Dermastore.Domain.Specifications.Questions;
using MediatR;

namespace Dermastore.Application.Commands.Questions
{
    public class DeleteQuestionHandler : IRequestHandler<DeleteQuestionCommand, bool>
    {
        private readonly IGenericRepository<Question> _questionRepository;
        public DeleteQuestionHandler(IGenericRepository<Question> questionRepository)
        {
            _questionRepository = questionRepository;
        }
        public async Task<bool> Handle(DeleteQuestionCommand request, CancellationToken cancellationToken)
        {
            var spec = new QuestionSpecification(request.Id);
            var question = await _questionRepository.GetEntityWithSpec(spec);

            _questionRepository.Delete(question);
            var result = await _questionRepository.SaveAllAsync();

            return result;
        }
    }
}
