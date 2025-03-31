using Dermastore.Application.Extensions;
using Dermastore.Domain.Enums;
using Dermastore.Domain.Interfaces;
using MediatR;

namespace Dermastore.Application.Commands.Users
{
    public class CreateStaffHandler : IRequestHandler<CreateStaffCommand, bool>
    {
        private readonly IUserService _userService;

        public CreateStaffHandler(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<bool> Handle(CreateStaffCommand request, CancellationToken cancellationToken)
        {
            var user = request.UserDto.StaffToEntity();

            if (user == null)
            {
                return false;
            }

            // Create and add user to customer role
            var result = await _userService.CreateUserAsync(user, request.UserDto.Password);
            result = await _userService.AddUserToRoleAsync(user, UserRole.Staff.ToString());

            return result.Succeeded;
        }
    }
}
