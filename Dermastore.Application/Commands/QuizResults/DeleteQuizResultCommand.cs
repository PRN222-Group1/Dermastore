using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dermastore.Application.Commands.QuizResults
{
    public class DeleteQuizResultCommand : IRequest<bool>
    {
        public int id { get; }
        public DeleteQuizResultCommand(int id)
        {
            this.id = id;
        }
    }
}
