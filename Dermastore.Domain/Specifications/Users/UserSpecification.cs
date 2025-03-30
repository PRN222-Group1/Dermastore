using Dermastore.Domain.Entities;
using Dermastore.Domain.Enums;

namespace Dermastore.Domain.Specifications.Users
{
    public class UserSpecification : BaseSpecification<User>
    {
        public UserSpecification(int id)
            : base(x => x.Id.Equals(id))
        {
            AddInclude(x => x.Membership);
        }

        public UserSpecification(string email)
            : base(x => x.Email.Equals(email)
            && x.Status == UserStatus.Active)
        {
            AddInclude(x => x.Membership);
        }

        public UserSpecification(UserSpecParams userSpecParams)
            : base(x => (string.IsNullOrEmpty(userSpecParams.Search)
                        || x.FirstName.ToLower().Contains(userSpecParams.Search.ToLower())
                        || x.LastName.ToLower().Contains(userSpecParams.Search.ToLower())
                        || x.Email.Contains(userSpecParams.Search.ToLower()))
                        && (string.IsNullOrEmpty(userSpecParams.Status)
                        || x.Status == ParseStatus<UserStatus>(userSpecParams.Status)))
        {
            AddInclude(x => x.Membership);

            if (!string.IsNullOrEmpty(userSpecParams.Sort))
            {
                switch (userSpecParams.Sort)
                {
                    case "nameAsc":
                        AddOrderBy(x => x.FirstName + " " + x.LastName);
                        break;
                    case "nameDesc":
                        AddOrderByDescending(x => x.FirstName + " " + x.LastName);
                        break;
                    default:
                        AddOrderBy(x => x.FirstName + " " + x.LastName);
                        break;
                }
            }

            ApplyPaging(userSpecParams.PageSize * (userSpecParams.PageIndex - 1),
                userSpecParams.PageSize);
        }
    }
}
