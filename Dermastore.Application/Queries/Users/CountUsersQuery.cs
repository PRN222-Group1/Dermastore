using Dermastore.Domain.Specifications.Users;
using MediatR;

namespace Dermastore.Application.Queries.Users
{
    public class CountUsersQuery : IRequest<int>
    {
        public UserSpecParams UserSpecParams { get; set; }

        public CountUsersQuery(UserSpecParams specParams)
        {
            UserSpecParams = specParams;
        }
    }
}
