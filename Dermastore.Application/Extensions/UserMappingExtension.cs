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
    }
}
