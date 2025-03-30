using Dermastore.Domain.Entities;
using Dermastore.Domain.Interfaces;
using Dermastore.Domain.Specifications;
using Dermastore.Domain.Specifications.Users;
using Dermastore.Infrastructure.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace Dermastore.Infrastructure.Services
{
    public class UserService : IUserService
    {
        private readonly UserManager<User> _userManager;

        public UserService(UserManager<User> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IdentityResult> AddUserToRoleAsync(User user, string role)
        {
            return await _userManager.AddToRoleAsync(user, role);
        }

        public async Task<IdentityResult> CreateUserAsync(User user, string password)
        {
            return await _userManager.CreateAsync(user, password);
        }

        public async Task<string> GetUserRoleAsync(User user)
        {
            var userRoles = await _userManager.GetRolesAsync(user);
            var userRole = userRoles.FirstOrDefault();
            return userRole;
        }

        private async Task<IList<User>> GetUsersInRoleAsync(string role)
        {
            return await _userManager.GetUsersInRoleAsync(role);
        }

        public async Task<User> GetUserWithSpec(ISpecification<User> spec)
        {
            return await ApplySpecification(_userManager.Users.AsQueryable(), spec).FirstOrDefaultAsync();
        }

        public async Task<IReadOnlyList<User>> ListAllUsersAsync()
        {
            return await _userManager.Users.ToListAsync();
        }

        public async Task<User> GetUserByClaims(ClaimsPrincipal principal)
        {
            return await _userManager.GetUserAsync(principal);
        }

        public async Task<User> GetUserByIdAsync(int id)
        {
            var spec = new UserSpecification(id);
            return await GetUserWithSpec(spec);
        }

        public async Task<IList<Claim>> GetUserClaims(User user)
        {
            return await _userManager.GetClaimsAsync(user);
        }

        public async Task<IReadOnlyList<User>> ListUsersAsync(ISpecification<User> spec)
        {
            var query = _userManager.Users.AsQueryable();
            return await ApplySpecification(query, spec).ToListAsync();
        }

        public async Task<int> CountAsync(ISpecification<User> spec)
        {
            var query = _userManager.Users.AsQueryable();
            query = spec.ApplyCriteria(query);
            return await query.CountAsync();
        }

        public async Task<IdentityResult> UpdateUserAsync(User user)
        {
            return await _userManager.UpdateAsync(user);
        }

        private IQueryable<User> ApplySpecification(IQueryable<User> query, ISpecification<User> spec)
        {
            return UserSpecificationEvaluator.GetQuery(query, spec);
        }
    }
}
