using Dermastore.Domain.Enums;
using Microsoft.AspNetCore.Identity;

namespace Dermastore.Domain.Entities
{
    public class User : IdentityUser<int>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Gender Gender { get; set; }
        public string Address { get; set; }
        public string ImageUrl { get; set; }
        public int Point { get; set; } = 0;
        public int MembershipId { get; set; }
        public Membership Membership { get; set; }
        public UserStatus Status { get; set; } = UserStatus.Active;
    }
}
