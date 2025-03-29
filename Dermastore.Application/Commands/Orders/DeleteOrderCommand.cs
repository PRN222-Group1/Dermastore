using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dermastore.Application.Commands.Orders
{
    public class DeleteOrderCommand : IRequest<bool>
    {
        public int Id { get; set; }

        public DeleteOrderCommand(int id)
        {
            this.Id = id;
        }
    }
}
