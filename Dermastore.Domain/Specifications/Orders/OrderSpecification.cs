using Dermastore.Domain.Entities.OrderAggregate;
using Dermastore.Domain.Enums;

namespace Dermastore.Domain.Specifications.Orders
{
    public class OrderSpecification : BaseSpecification<Order>
    {
        public OrderSpecification() : base(x => x.Status == OrderStatus.Completed)
        {
            AddInclude(p => p.OrderItems);
            AddOrderBy(p => p.Id);
        }

        public OrderSpecification(OrderSpecParams specParams)
            : base(x => 
            (string.IsNullOrEmpty(specParams.Search)
            || x.User.PhoneNumber.Equals(specParams.Search)
            || x.User.Email.ToLower().Equals(specParams.Search.ToLower())) 
            && (!specParams.UserId.HasValue || x.User.Id == specParams.UserId.Value)
            && (!specParams.Year.HasValue || x.OrderDate.Year == specParams.Year.Value)
            && (string.IsNullOrEmpty(specParams.Status) || x.Status == ParseStatus<OrderStatus>(specParams.Status)))
        {
            AddInclude(p => p.User);
            AddInclude(p => p.OrderItems);
            AddInclude(p => p.DeliveryMethod);
            AddInclude(p => p.Promotion);
            AddInclude(p => p.Membership);

            ApplyPaging(specParams.PageSize * (specParams.PageIndex - 1),
                specParams.PageSize);

            AddOrderByDescending(x => x.OrderDate);

            if (!string.IsNullOrEmpty(specParams.Sort))
            {
                switch (specParams.Sort)
                {
                    case "dateAsc":
                        AddOrderBy(x => x.OrderDate);
                        AddOrderByDescending(null);
                        break;
                    case "dateDesc":
                        AddOrderByDescending(x => x.OrderDate);
                        break;
                    default:
                        AddOrderByDescending(x => x.OrderDate);
                        break;
                }
            }
        }

        public OrderSpecification(int id) : base(x => x.Id == id)
        {
            AddInclude(p => p.User);
            AddInclude(p => p.OrderItems);
            AddInclude(p => p.DeliveryMethod);
            AddInclude(p => p.Promotion);
            AddInclude(p => p.Membership);
        }
    }
}
