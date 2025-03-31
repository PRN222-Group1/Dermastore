using Dermastore.Application.DTOs.AccountDTOs;
using Dermastore.Domain.Specifications.Users;
using MediatR;

namespace Dermastore.Application.Queries.Users
{
    public class GetUsersQuery : IRequest<IReadOnlyList<UserDto>>
    {
        public UserSpecParams UserSpecParams { get; set; }

        public GetUsersQuery(UserSpecParams specParams)
        {
            UserSpecParams = specParams;
        }
    }
}
