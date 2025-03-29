using Dermastore.Application.DTOs;
using Dermastore.Domain.Entities;

namespace Dermastore.Application.Extensions
{
    public static class UserMappingExtension
    {
        public static UserDto? ToDto(this User? user)
        {
            if (user == null) return null;
            return new UserDto
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Address = user.Address,
                Email = user.Email ?? string.Empty,
                PhoneNumber = user.PhoneNumber ?? string.Empty,
                Gender = user.Gender.ToString(),
                ImageUrl = user.ImageUrl ?? string.Empty,
                Membership = user.Membership != null 
                    ? user.Membership.ToDto() : null,
            };
        }

        public static void UpdateFromDto(this User? user, UserDto userDto)
        {
            if (userDto == null) throw new ArgumentNullException(nameof(userDto));
            if (user == null) throw new ArgumentNullException(nameof(user));

            user.FirstName = userDto.FirstName;
            user.LastName = userDto.LastName;
            user.Address = userDto.Address;
            user.Email = userDto.Email;
            user.PhoneNumber = userDto.PhoneNumber;
        }
    }
}
