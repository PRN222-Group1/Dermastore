using Dermastore.Domain.Specifications.Orders;
using MediatR;

namespace Dermastore.Application.Queries.Orders.GetOrders
{
    public class CountOrdersQuery : IRequest<int>
    {
        public OrderSpecParams OrderSpecParams;

        public CountOrdersQuery(OrderSpecParams orderSpecParams)
        {
            OrderSpecParams = orderSpecParams;
        }
    }
}
