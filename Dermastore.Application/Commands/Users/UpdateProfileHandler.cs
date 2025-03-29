using Dermastore.Application.Extensions;
using Dermastore.Domain.Interfaces;
using MediatR;

namespace Dermastore.Application.Commands.Users
{
    public class UpdateProfileHandler : IRequestHandler<UpdateProfileCommand, bool>
    {
        private readonly IUserService _userService;

        public UpdateProfileHandler(IUserService userService)
        {
            _userService = userService;
        }
        public async Task<bool> Handle(UpdateProfileCommand request, CancellationToken cancellationToken)
        {
            var profile = await _userService.GetUserByIdAsync(request.Profile.Id);
            if (profile == null)
            {
                return false;
            }

            profile.UpdateProfileFromDto(request.Profile);

            var result = await _userService.UpdateUserAsync(profile);
            return result.Succeeded ? true : false;
        }
    }
}
