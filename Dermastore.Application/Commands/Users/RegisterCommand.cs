using Dermastore.Application.DTOs.AccountDTOs;
using MediatR;

namespace Dermastore.Application.Commands.Users
{
    public class RegisterCommand : IRequest<bool>
    {
        public RegisterDto RegisterDto { get; set; }

        public RegisterCommand(RegisterDto registerDto)
        {
            RegisterDto = registerDto;
        }
    }
}
