using Dermastore.Domain.Interfaces;
using Dermastore.Domain.Specifications.Users;
using MediatR;

namespace Dermastore.Application.Queries.Users
{
    public class CountUsersHandler : IRequestHandler<CountUsersQuery, int>
    {
        private readonly IUserService _userService;

        public CountUsersHandler(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<int> Handle(CountUsersQuery request, CancellationToken cancellationToken)
        {
            var spec = new UserSpecification(request.UserSpecParams);
            var count = await _userService.CountAsync(spec);
            return count;
        }
    }
}
