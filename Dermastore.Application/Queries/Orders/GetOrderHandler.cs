using Dermastore.Application.DTOs.Orders;
using Dermastore.Application.Extensions;
using Dermastore.Domain.Entities.OrderAggregate;
using Dermastore.Domain.Interfaces;
using Dermastore.Domain.Specifications.Orders;
using MediatR;

namespace Dermastore.Application.Queries.Orders
{
    public class GetOrderHandler : IRequestHandler<GetOrderQuery, OrderDto>
    {
        private readonly IGenericRepository<Order> _orderRepository;

        public GetOrderHandler(IGenericRepository<Order> orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task<OrderDto> Handle(GetOrderQuery request, CancellationToken cancellationToken)
        {
            var spec = new OrderSpecification(request.Id);
            var order = await _orderRepository.GetEntityWithSpec(spec);
            return order.ToDto();
        }
    }
}
