using Dermastore.Application.DTOs.QuestionDTOs;
using Dermastore.Domain.Entities;

namespace Dermastore.Application.Extensions
{
    public static class QuestionMappingExtension
    {
        public static Question ToEntity(this QuestionToAddDTO questionToAddDto)
        {
            if (questionToAddDto == null) throw new ArgumentNullException(nameof(questionToAddDto));
            return new Question
            {
                Content = questionToAddDto.content,
            };
        }

        public static QuestionDto ToDto(this Question question)
        {
            if (question == null) return null;
            return new QuestionDto
            {
                id = question.Id,
                content = question.Content,
                answers = question.Answers.Select(a => a.ToDto()).ToList()
            };
        }
    }
}
