using Dermastore.Domain.Entities;
using MediatR;

namespace Dermastore.Application.Queries.Users
{
    public class GetUserQuery : IRequest<User>
    {
        public string Email { get; }

        public GetUserQuery(string email)
        {
            Email = email;
        }
    }
}
