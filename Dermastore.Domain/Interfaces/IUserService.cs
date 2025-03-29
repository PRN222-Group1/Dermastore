using Dermastore.Domain.Entities;
using Dermastore.Domain.Specifications;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace Dermastore.Domain.Interfaces
{
    public interface IUserService
    {
        Task<IReadOnlyList<User>> ListAllUsersAsync();
        Task<User> GetUserWithSpec(ISpecification<User> spec);
        Task<IReadOnlyList<User>> ListUsersAsync(ISpecification<User> spec);
        Task<int> CountAsync(ISpecification<User> spec);
        Task<string> GetUserRoleAsync(User user);
        Task<IdentityResult> AddUserToRoleAsync(User user, string role);
        Task<IdentityResult> CreateUserAsync(User user, string password);
        Task<IdentityResult> UpdateUserAsync(User user);
        Task<User> GetUserByClaims(ClaimsPrincipal principal);
        Task<User> GetUserByIdAsync(int id);
        Task<IList<Claim>> GetUserClaims(User user);
    }
}
