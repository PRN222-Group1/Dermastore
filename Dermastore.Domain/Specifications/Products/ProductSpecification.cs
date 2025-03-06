using Dermastore.Domain.Entities;
using Dermastore.Domain.Enums;

namespace Dermastore.Domain.Specifications.Products
{
    public class ProductSpecification : BaseSpecification<Product>
    {
        public ProductSpecification() : base(x => 
            x.Status == ParseStatus("InStock")
        )
        {
            AddInclude(p => p.SubCategory);
            AddOrderBy(p => p.Name);
        }

        public ProductSpecification(int id) : base(x => x.Id == id)
        {
            AddInclude(p => p.SubCategory);
        }

        private static ProductStatus? ParseStatus(string status)
        {
            if (Enum.TryParse<ProductStatus>(status, true, out var result)) return result;
            return null;
        }
    }
}
