using Dermastore.Domain.Entities;
using Dermastore.Domain.Enums;

namespace Dermastore.Domain.Specifications.Blogs
{
    public class BlogSpecification : BaseSpecification<Blog>
    {
        public BlogSpecification(BlogSpecParams specParams) 
            : base(x => (string.IsNullOrEmpty(specParams.Search)
                    || x.Title.ToLower().Contains(specParams.Search.ToLower()))
                    && (string.IsNullOrEmpty(specParams.Status) || x.Status == ParseStatus<BlogStatus>(specParams.Status)))
        {
            AddInclude(p => p.User);
            AddOrderBy(p => p.Id);

            ApplyPaging(specParams.PageSize * (specParams.PageIndex - 1),
                specParams.PageSize);

            if (!string.IsNullOrEmpty(specParams.Sort))
            {
                switch (specParams.Sort)
                {
                    case "nameAsc":
                        AddOrderBy(x => x.Title);
                        break;
                    case "nameDesc":
                        AddOrderByDescending(x => x.Title);
                        break;
                    case "dateAsc":
                        AddOrderBy(x => x.DatePublished);
                        break;
                    case "dateDesc":
                        AddOrderByDescending(x => x.DatePublished);
                        break;
                    default:
                        AddOrderByDescending(x => x.DatePublished);
                        break;
                }
            }
        }

        public BlogSpecification(int id) : base(x => x.Id == id)
        {
            AddInclude(p => p.User);
        }
    }
}
