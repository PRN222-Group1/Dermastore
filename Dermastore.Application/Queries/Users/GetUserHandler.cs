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
            var spec = new UserSpecification(0);

            if (request.Id.HasValue)
            {
                spec = new UserSpecification(request.Id.Value);
            }
            else if (!string.IsNullOrEmpty(request.Email))
            {
                spec = new UserSpecification(request.Email);
            }

            var user = await _userService.GetUserWithSpec(spec);
            return user;
        }
    }
}
