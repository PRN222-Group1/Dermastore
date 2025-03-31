using Dermastore.Domain.Entities;
using Dermastore.Domain.Enums;

namespace Dermastore.Domain.Specifications.Products
{
    public class ProductSpecification : BaseSpecification<Product>
    {
        public ProductSpecification() : base(x => 
            x.Status == ParseStatus<ProductStatus>("InStock")
        )
        {
            AddInclude(p => p.SubCategory);
            AddInclude(p => p.Brand);
            AddOrderBy(p => p.Name);
        }

        public ProductSpecification(ProductSpecParams productParams)
            : base(x => (string.IsNullOrEmpty(productParams.Search)
            || x.Name.ToLower().Contains(productParams.Search.ToLower())) &&
            (!productParams.SubCategoryIds.Any() || productParams.SubCategoryIds.Contains(x.SubCategoryId)) &&
            (!productParams.BrandIds.Any() || productParams.BrandIds.Contains(x.BrandId)) &&
            ((!productParams.StartPrice.HasValue || !productParams.EndPrice.HasValue) 
            || (x.Price >= productParams.StartPrice && x.Price <= productParams.EndPrice)) &&
            (string.IsNullOrEmpty(productParams.Status) || x.Status == ParseStatus<ProductStatus>(productParams.Status))
        )
        {
            AddInclude(p => p.SubCategory);
            AddInclude(p => p.Brand);
            AddInclude(p => p.Answer);
            ApplyPaging(productParams.PageSize * (productParams.PageIndex - 1),
                productParams.PageSize);

            if (!string.IsNullOrEmpty(productParams.Sort))
            {
                switch (productParams.Sort)
                {
                    case "nameAsc":
                        AddOrderBy(x => x.Name);
                        break;
                    case "nameDesc":
                        AddOrderByDescending(x => x.Name);
                        break;
                    case "priceAsc":
                        AddOrderBy(x => x.Price);
                        break;
                    case "priceDesc":
                        AddOrderByDescending(x => x.Price);
                        break;
                    default:
                        AddOrderBy(x => x.Name);
                        break;
                }
            }
        }

        public ProductSpecification(int id) : base(x => x.Id == id)
        {
            AddInclude(p => p.SubCategory);
            AddInclude(p => p.Brand);
        }

        public ProductSpecification(List<int> answerIds) : base(p => answerIds.Contains(p.AnswerId) && p.Status == ParseStatus<ProductStatus>("InStock"))
        {
            AddInclude(p => p.Answer);
            AddOrderBy(p => p.Name);
        }
    }
}
