using Dermastore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dermastore.Application.DTOs.Blogs
{
    public class BlogToAddDto
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public string UserId { get; set; }
        public DateOnly DatePublished { get; set; } = DateOnly.FromDateTime(DateTime.Now);
    }
}
