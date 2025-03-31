using Dermastore.Application.DTOs;
using MediatR;

namespace Dermastore.Application.Queries.DeliveryMethods
{
    public class GetDeliveryMethodsQuery : IRequest<IReadOnlyList<DeliveryMethodDto>>
    {
    }
}
