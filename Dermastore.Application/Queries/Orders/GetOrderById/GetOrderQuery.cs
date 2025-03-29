using Dermastore.Application.DTOs.Blogs;
using Dermastore.Application.DTOs.Orders;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dermastore.Application.Queries.Orders.GetOrderById
{
    public class GetOrderQuery : IRequest<OrderDto>
    {
        public int Id { get; }

        public GetOrderQuery(int id)
        {
            Id = id;
        }
    }
}
