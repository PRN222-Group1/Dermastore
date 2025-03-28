using Dermastore.Application.DTOs.AnswerDTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dermastore.Application.Queries.Answers
{
    public class GetAnswerQuery : IRequest<AnswerDto>
    {
        public int Id { get; }
        public GetAnswerQuery(int id)
        {
            Id = id;
        }
    }
}
