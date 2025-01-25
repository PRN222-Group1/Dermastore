using Dermastore.Core.Enums;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dermastore.Core.Entities
{
    public class User : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Gender Gender { get; set; }
        public string Address { get; set; }
        public string ImageUrl { get; set; }
        public int MembershipId { get; set; }
        public Membership Membership { get; set; }
        public UserStatus Status { get; set; } = UserStatus.Active;
    }
}
