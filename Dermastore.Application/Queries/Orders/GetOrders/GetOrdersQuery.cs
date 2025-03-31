using Dermastore.Application.DTOs.Orders;
using Dermastore.Domain.Specifications.Orders;
using MediatR;

namespace Dermastore.Application.Queries.Orders.GetOrders
{
    public class GetOrdersQuery : IRequest<IReadOnlyList<OrderDto>>
    {
        public OrderSpecParams OrderSpecParams { get; set; }
        public GetOrdersQuery(OrderSpecParams orderSpecParams) 
        { 
            OrderSpecParams = orderSpecParams;
        }
    }
}
