using Dermastore.Application.DTOs;
using Dermastore.Application.Extensions;
using Dermastore.Domain.Entities;
using Dermastore.Domain.Interfaces;
using Dermastore.Domain.Specifications.Users;
using MediatR;

namespace Dermastore.Application.Queries.Users
{
    public class GetUserHandler : IRequestHandler<GetUserQuery, User>
    {
        private readonly IUserService _userService;

        public GetUserHandler(IUserService userService) 
        {
            _userService = userService;
        }

        public async Task<User> Handle(GetUserQuery request, CancellationToken cancellationToken)
        {
            var spec = new UserSpecification(request.Email);
            var user = await _userService.GetUserWithSpec(spec);
            return user;
        }
    }
}
