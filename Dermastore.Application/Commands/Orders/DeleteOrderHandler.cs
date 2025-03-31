using Dermastore.Application.Commands.Blogs;
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
    public class DeleteOrderHandler : IRequestHandler<DeleteOrderCommand, bool>
    {
        private readonly IGenericRepository<Order> _orderRepository;

        public DeleteOrderHandler(IGenericRepository<Order> orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task<bool> Handle(DeleteOrderCommand request, CancellationToken cancellationToken)
        {
            var spec = new OrderSpecification(request.Id);
            var order = await _orderRepository.GetEntityWithSpec(spec);

            _orderRepository.Delete(order);
            var result = await _orderRepository.SaveAllAsync();

            return result;
        }
    }
}
