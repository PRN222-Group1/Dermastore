using Dermastore.Application.DTOs.AccountDTOs;
using MediatR;

namespace Dermastore.Application.Commands.Users
{
    public class UpdateProfileCommand : IRequest<bool>
    {
        public ProfileToUpdateDto Profile { get; set; }

        public UpdateProfileCommand(ProfileToUpdateDto profile) 
        {
            Profile = profile;
        }
    }
}
