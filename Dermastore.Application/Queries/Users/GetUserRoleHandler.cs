using Dermastore.Application.DTOs;
using Dermastore.Application.Extensions;
using Dermastore.Domain.Entities;
using Dermastore.Domain.Interfaces;
using Dermastore.Domain.Specifications.Users;
using MediatR;

namespace Dermastore.Application.Queries.Users
{
    public class GetUserRoleHandler : IRequestHandler<GetUserRoleQuery, string>
    {
        private readonly IUserService _userService;

        public GetUserRoleHandler(IUserService userService) 
        {
            _userService = userService;
        }

        public async Task<string> Handle(GetUserRoleQuery request, CancellationToken cancellationToken)
        {
            var role = await _userService.GetUserRoleAsync(request.User);
            return role;
        }
    }
}
