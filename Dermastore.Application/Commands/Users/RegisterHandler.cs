using Dermastore.Application.Extensions;
using Dermastore.Domain.Enums;
using Dermastore.Domain.Interfaces;
using MediatR;

namespace Dermastore.Application.Commands.Users
{
    public class RegisterHandler : IRequestHandler<RegisterCommand, bool>
    {
        private readonly IUserService _userService;

        public RegisterHandler(IUserService userService) 
        {
            _userService = userService;
        }

        public async Task<bool> Handle(RegisterCommand request, CancellationToken cancellationToken)
        {
            var user = request.RegisterDto.ToEntity();

            if (user == null)
            {
                return false;
            }

            // Create and add user to customer role
            var result = await _userService.CreateUserAsync(user, request.RegisterDto.Password);
            result = await _userService.AddUserToRoleAsync(user, UserRole.Customer.ToString());

            return result.Succeeded;
        }
    }
}
