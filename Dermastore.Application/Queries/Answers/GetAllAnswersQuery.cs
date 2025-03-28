using Dermastore.Application.DTOs.AnswerDTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dermastore.Application.Queries.Answers
{
    public class GetAllAnswersQuery : IRequest<IReadOnlyList<AnswerDto>>
    {
    }
}
