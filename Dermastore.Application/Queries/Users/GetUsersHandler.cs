using Dermastore.Application.DTOs.AccountDTOs;
using Dermastore.Application.Extensions;
using Dermastore.Domain.Interfaces;
using Dermastore.Domain.Specifications.Users;
using MediatR;

namespace Dermastore.Application.Queries.Users
{
    public class GetUsersHandler : IRequestHandler<GetUsersQuery, IReadOnlyList<UserDto>>
    {
        private readonly IUserService _userService;

        public GetUsersHandler(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<IReadOnlyList<UserDto>> Handle(GetUsersQuery request, CancellationToken cancellationToken)
        {
            var spec = new UserSpecification(request.UserSpecParams);
            var users = await _userService.ListUsersAsync(spec);

            var userDtos = users.Select(u => u.ToDto());

            return userDtos.ToList();
        }
    }
}
