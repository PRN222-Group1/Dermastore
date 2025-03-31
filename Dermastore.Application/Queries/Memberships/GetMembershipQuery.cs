using Dermastore.Application.DTOs;
using MediatR;

namespace Dermastore.Application.Queries.Memberships
{
    public class GetMembershipQuery : IRequest<MembershipDto>
    {
        public int Id { get; }

        public GetMembershipQuery(int id)
        {
            Id = id;
        }
    }
}
