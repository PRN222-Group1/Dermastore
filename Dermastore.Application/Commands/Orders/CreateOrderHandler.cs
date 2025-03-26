using Dermastore.Application.Commands.Blogs;
using Dermastore.Application.Extensions;
using Dermastore.Domain.Entities;
using Dermastore.Domain.Entities.OrderAggregate;
using Dermastore.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dermastore.Application.Commands.Orders
{
    public class CreateOrderHandler : IRequestHandler<CreateOrderCommand, int>
    {
        private readonly IGenericRepository<Order> _orderRepository;

        public CreateOrderHandler(IGenericRepository<Order> orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task<int> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            var order = request.OrderDto.ToEntity();
            _orderRepository.Add(order);
            await _orderRepository.SaveAllAsync();

            return order.Id;
        }
    }
}
