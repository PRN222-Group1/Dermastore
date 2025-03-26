using Dermastore.Application.DTOs.QuestionDTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dermastore.Application.Queries.Questions
{
    public class GetQuestionsQuery : IRequest<IReadOnlyList<QuestionDto>>
    {
    }
}
