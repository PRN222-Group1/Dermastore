using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dermastore.Application.DTOs.Blogs
{
    public class BlogToUpdateDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public int UserId { get; set; }
        public DateOnly DatePublished { get; set; } = DateOnly.FromDateTime(DateTime.Now);
    }
}
