using Dermastore.Application.DTOs.Blogs;
using Dermastore.Application.DTOs.Orders;
using Dermastore.Application.Extensions;
using Dermastore.Application.Queries.Blogs;
using Dermastore.Domain.Entities;
using Dermastore.Domain.Entities.OrderAggregate;
using Dermastore.Domain.Interfaces;
using Dermastore.Domain.Specifications.Blogs;
using Dermastore.Domain.Specifications.Orders;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dermastore.Application.Queries.Orders.GetOrders
{
    public class GetOrdersHandler : IRequestHandler<GetOrdersQuery, IReadOnlyList<OrderDto>>
    {
        private readonly IGenericRepository<Order> _orderRepository;

        public GetOrdersHandler(IGenericRepository<Order> orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task<IReadOnlyList<OrderDto>> Handle(GetOrdersQuery request, CancellationToken cancellationToken)
        {
            var spec = new OrderSpecification();
            var orders = await _orderRepository.ListAsync(spec);
            var ordersToReturn = orders.Select(p => p.ToDto()).ToList();
            return ordersToReturn;
        }
    }
}
