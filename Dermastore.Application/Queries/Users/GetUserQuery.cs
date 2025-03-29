using Dermastore.Domain.Entities;
using MediatR;

namespace Dermastore.Application.Queries.Users
{
    public class GetUserQuery : IRequest<User>
    {
        public int? Id { get; }

        public string? Email { get; }

        public GetUserQuery(int? id)
        {
            Id = id;
        }

        public GetUserQuery(string? email)
        {
            Email = email;
        }
    }
}
