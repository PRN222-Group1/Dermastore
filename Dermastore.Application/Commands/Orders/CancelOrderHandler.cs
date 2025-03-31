using Dermastore.Domain.Entities.OrderAggregate;
using Dermastore.Domain.Interfaces;
using Dermastore.Domain.Specifications.Orders;
using MediatR;

namespace Dermastore.Application.Commands.Orders
{
    public class CancelOrderHandler : IRequestHandler<CancelOrderCommand, bool>
    {
        private readonly IGenericRepository<Order> _orderRepo;

        public CancelOrderHandler(IGenericRepository<Order> orderRepo) 
        {
            _orderRepo = orderRepo;
        }
        public async Task<bool> Handle(CancelOrderCommand request, CancellationToken cancellationToken)
        {
            var spec = new OrderSpecification(request.Id);
            var order = await _orderRepo.GetEntityWithSpec(spec);
            if (order == null)
            {
                return false;
            }

            order.Status = Domain.Enums.OrderStatus.Cancelled;
            _orderRepo.Update(order);
            var result = await _orderRepo.SaveAllAsync();

            return result;
        }
    }
}
