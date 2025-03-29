using Dermastore.Application.DTOs;
using Dermastore.Application.Extensions;
using Dermastore.Domain.Entities;
using Dermastore.Domain.Interfaces;
using MediatR;

namespace Dermastore.Application.Queries.DeliveryMethods
{
    public class GetDeliveryMethodsHandler : IRequestHandler<GetDeliveryMethodsQuery, IReadOnlyList<DeliveryMethodDto>>
    {
        private readonly IGenericRepository<DeliveryMethod> _deliveryMethodRepo;

        public GetDeliveryMethodsHandler(IGenericRepository<DeliveryMethod> deliveryMethodRepo)
        {
            _deliveryMethodRepo = deliveryMethodRepo;
        }

        public async Task<IReadOnlyList<DeliveryMethodDto>> Handle(GetDeliveryMethodsQuery request, CancellationToken cancellationToken)
        {
            var methods = await _deliveryMethodRepo.ListAllAsync();
            return methods.Select(m => m.ToDto()).ToList();
        }
    }
}
