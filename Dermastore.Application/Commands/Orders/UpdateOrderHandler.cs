using Dermastore.Application.Commands.Blogs;
using Dermastore.Application.Extensions;
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

namespace Dermastore.Application.Commands.Orders
{
    public class UpdateOrderHandler : IRequestHandler<UpdateOrderCommand, int>
    {
        private readonly IGenericRepository<Order> _orderRepository;

        public UpdateOrderHandler(IGenericRepository<Order> orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task<int> Handle(UpdateOrderCommand request, CancellationToken cancellationToken)
        {
            var spec = new OrderSpecification(request.OrderDto.Id);
            var order = await _orderRepository.GetEntityWithSpec(spec);

            order.UpdateFromDto(request.OrderDto);
            _orderRepository.Update(order);
            await _orderRepository.SaveAllAsync();

            return order.Id;
        }
    }
}
