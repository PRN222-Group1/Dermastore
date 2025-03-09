using Dermastore.Application.DTOs;
using Dermastore.Application.DTOs.AnswerDTOs;
using Dermastore.Application.DTOs.QuestionDTOs;
using Dermastore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dermastore.Application.Extensions
{
    public static class AnswerMappingExtenstion
    {
        public static AnswerDto ToDto(this Answer answer)
        {
            if (answer == null)
            {
                return null;
            }
            return new AnswerDto
            {
                id = answer.Id,
                content = answer.Content,
                questionId =  answer.QuestionId,
            };
        }
    }
}
