using Dermastore.Application.DTOs;
using Dermastore.Application.Extensions;
using Dermastore.Domain.Entities;
using Dermastore.Domain.Interfaces;
using Dermastore.Domain.Specifications.Promotions;
using MediatR;

namespace Dermastore.Application.Queries.Memberships
{
    public class GetMembershipHandler : IRequestHandler<GetMembershipQuery, MembershipDto>
    {
        private readonly IGenericRepository<Membership> _membership;

        public GetMembershipHandler(IGenericRepository<Membership> membership)
        {
            _membership = membership;
        }

        public async Task<MembershipDto> Handle(GetMembershipQuery request, CancellationToken cancellationToken)
        {
            var membership = await _membership.GetByIdAsync(request.Id);
            return membership.ToDto();
        }
    }
}
