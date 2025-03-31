using Dermastore.Application.DTOs.AccountDTOs;
using Dermastore.Domain.Entities;
using Dermastore.Domain.Enums;

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
                Point = user.Point,
                Membership = user.Membership != null 
                    ? user.Membership.ToDto() : null,
                Status = user.Status.ToString(),
            };
        }

        public static User? ToEntity(this RegisterDto? user)
        {
            if (user == null) return null;
            return new User
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                Address = user.Address,
                Email = user.Email ?? string.Empty,
                UserName = user.Email,
                PhoneNumber = user.PhoneNumber ?? string.Empty,
                Gender = (Gender) user.Gender,
                ImageUrl = string.Empty,
                MembershipId = 1,
                Status = UserStatus.Active,
            };
        }

        public static User? StaffToEntity(this UserToAddDto? user)
        {
            if (user == null) return null;
            return new User
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                Address = user.Address,
                Email = user.Email ?? string.Empty,
                UserName = user.Email,
                PhoneNumber = user.PhoneNumber ?? string.Empty,
                Gender = (Gender)user.Gender,
                ImageUrl = string.Empty,
                MembershipId = 1,
                Status = UserStatus.Active,
            };
        }

        public static void UpdateShippingFromDto(this User? user, UserDto userDto)
        {
            if (userDto == null) throw new ArgumentNullException(nameof(userDto));
            if (user == null) throw new ArgumentNullException(nameof(user));

            user.FirstName = userDto.FirstName;
            user.LastName = userDto.LastName;
            user.Address = userDto.Address;
            user.Email = userDto.Email;
            user.PhoneNumber = userDto.PhoneNumber;
        }

        public static void UpdateProfileFromDto(this User? user, ProfileToUpdateDto profileDto)
        {
            if (profileDto == null) throw new ArgumentNullException(nameof(profileDto));
            if (user == null) throw new ArgumentNullException(nameof(user));

            user.FirstName = profileDto.FirstName;
            user.LastName = profileDto.LastName;
            user.Address = profileDto.Address;
            user.Email = profileDto.Email;
            user.PhoneNumber = profileDto.PhoneNumber;
            user.Gender =  (Gender) profileDto.Gender;
        }
    }
}
