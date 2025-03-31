using Dermastore.Domain.Enums;
using Dermastore.Domain.Interfaces;
using MediatR;

namespace Dermastore.Application.Commands.Users
{
    public class UpdateUserStatusHandler : IRequestHandler<UpdateUserStatusCommand, bool>
    {
        private readonly IUserService _userService;

        public UpdateUserStatusHandler(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<bool> Handle(UpdateUserStatusCommand request, CancellationToken cancellationToken)
        {
            var user = await _userService.GetUserByIdAsync(request.Id);
            if (user == null)
            {
                return false;
            }

            user.Status = (UserStatus)request.Status;

            var result = await _userService.UpdateUserAsync(user);
            return result.Succeeded;
        }
    }
}
