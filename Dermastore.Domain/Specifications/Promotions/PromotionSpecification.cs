using Dermastore.Domain.Entities;
using Dermastore.Domain.Enums;

namespace Dermastore.Domain.Specifications.Promotions
{
    public class PromotionSpecification : BaseSpecification<Promotion>
    {
        public PromotionSpecification() : base(x =>
            x.Status == ParseStatus<PromotionStatus>("Active")
        )
        {
            AddOrderBy(p => p.Name);
        }

        public PromotionSpecification(int id) : base(x =>
            x.Id == id &&
            x.Status == ParseStatus<PromotionStatus>("Active")
        )
        {
        }

        public PromotionSpecification(string code) : base(x =>
            x.Code == code &&
            x.Status == ParseStatus<PromotionStatus>("Active")
        )
        {
        }
    }
}
