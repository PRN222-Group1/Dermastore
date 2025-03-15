using Dermastore.Application.DTOs;
using Dermastore.Domain.Entities;

namespace Dermastore.Application.Extensions
{
    public static class MembershipMappingExtension
    {
        public static MembershipDto ToDto(this Membership membership)
        {
            if (membership == null) return null;

            return new MembershipDto
            {
                Id = membership.Id,
                Name = membership.Name,
                MinPoint = membership.MinPoint,
                Discount = membership.Discount
            };
        }
    }
}
