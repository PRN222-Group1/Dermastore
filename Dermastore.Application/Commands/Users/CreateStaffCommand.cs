using Dermastore.Application.DTOs.AccountDTOs;
using MediatR;

namespace Dermastore.Application.Commands.Users
{
    public class CreateStaffCommand : IRequest<bool>
    {
        public UserToAddDto UserDto { get; set; }

        public CreateStaffCommand(UserToAddDto userDto)
        {
            UserDto = userDto;
        }
    }
}
