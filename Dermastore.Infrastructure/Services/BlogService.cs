using Dermastore.Domain.Entities;
using Dermastore.Domain.Entities.OrderAggregate;
using Dermastore.Domain.Interfaces;
using Dermastore.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dermastore.Infrastructure.Services
{
    public class BlogService : IBlogService
    {
        private readonly DermastoreContext _context;

        public BlogService(DermastoreContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Blog>> GetBlogs()
        {
            return await _context.Blogs
                        .AsNoTracking()
                        .ToListAsync();
        }

        public async Task<Blog> GetBlogById(int blogId)
        {
            return await _context.Blogs
                .AsNoTracking()
                .FirstOrDefaultAsync(o => o.Id == blogId);
        }

        public void CreateBlog(Blog blog)
        {
            _context.Blogs.AddAsync(blog);
        }

        public void Update(Blog blog)
        {
            _context.Blogs.Update(blog);
        }

        public void Remove(Blog blog)
        {
            _context.Blogs.Remove(blog);
        }
    }
}
