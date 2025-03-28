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
        private readonly IUnitOfWork _unitOfWork;

        public UpdateOrderHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<int> Handle(UpdateOrderCommand request, CancellationToken cancellationToken)
        {
            var order = await _unitOfWork.Orders.GetOrderById(request.OrderDto.Id);
            _unitOfWork.Orders.Update(order);
            await _unitOfWork.Complete();

            return order.Id;
        }
    }
}
