using Dermastore.Domain.Entities;

namespace Dermastore.Domain.Specifications.Products
{
    public class CategorySpecification : BaseSpecification<Category>
    {
        public CategorySpecification() 
        {
            AddInclude(c => c.SubCategories);
        }
    }
}
