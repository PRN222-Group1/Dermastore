using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dermastore.Application.Commands.Questions
{
    public class DeleteQuestionCommand : IRequest<bool>
    {
        public int Id { get; }
        public DeleteQuestionCommand(int id)
        {
            Id = id;
        }
    }
}
