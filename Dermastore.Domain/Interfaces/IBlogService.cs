using Dermastore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dermastore.Domain.Interfaces
{
    public interface IBlogService
    {
        Task<IEnumerable<Blog>> GetBlogs();
        Task<Blog> GetBlogById(int blogId);
        void CreateBlog(Blog blog);
        void Update(Blog blog);
        void Remove(Blog blog);
    }
}
