using Dermastore.Application.DTOs.Blogs;
using Dermastore.Application.DTOs.Orders;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dermastore.Application.Commands.Orders
{
    public class UpdateOrderCommand : IRequest<int>
    {
        public OrderToUpdateDto OrderDto { get; }

        public UpdateOrderCommand(OrderToUpdateDto orderDto)
        {
            OrderDto = orderDto;
        }
    }
}
