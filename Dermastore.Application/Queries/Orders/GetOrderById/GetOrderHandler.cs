using Dermastore.Application.DTOs.Orders;
using Dermastore.Application.Extensions;
using Dermastore.Domain.Entities.OrderAggregate;
using Dermastore.Domain.Interfaces;
using Dermastore.Domain.Specifications.Orders;
using MediatR;

namespace Dermastore.Application.Queries.Orders.GetOrderById
{
    public class GetOrderHandler : IRequestHandler<GetOrderQuery, OrderDto>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetOrderHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<OrderDto> Handle(GetOrderQuery request, CancellationToken cancellationToken)
        {
            var order = await _unitOfWork.Orders.GetOrderById(request.Id);
            return order.ToDto();
        }
    }
}
