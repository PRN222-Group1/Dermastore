using Dermastore.Application.DTOs.Orders;
using MediatR;

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
