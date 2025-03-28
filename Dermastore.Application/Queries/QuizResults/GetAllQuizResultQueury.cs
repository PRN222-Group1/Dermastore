using Dermastore.Application.DTOs.QuizResultDTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dermastore.Application.Queries.QuizResults
{
    public class GetAllQuizResultQueury : IRequest<IReadOnlyList<QuizResultResponseDto>>
    {
    }
}
