using Dermastore.Application.DTOs;
using Dermastore.Domain.Entities;
using MediatR;

namespace Dermastore.Application.Queries.Users
{
    public class GetUserRoleQuery : IRequest<string>
    {
        public User User { get; }

        public GetUserRoleQuery(User user)
        {
            User = user;
        }
    }
}
