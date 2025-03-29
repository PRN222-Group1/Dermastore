using Dermastore.Domain.Entities;
using Dermastore.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dermastore.Domain.Specifications.Blogs
{
    public class BlogSpecification : BaseSpecification<Blog>
    {
        public BlogSpecification() 
        {
            AddInclude(p => p.User);
            AddOrderBy(p => p.Id);
        }

        public BlogSpecification(int id) : base(x => x.Id == id)
        {
            AddInclude(p => p.User);
        }

        
    }
}
