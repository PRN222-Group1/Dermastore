using Dermastore.Application.DTOs.Blogs;
using Dermastore.Domain.Entities;
using Dermastore.Domain.Enums;

namespace Dermastore.Application.Extensions
{
    public static class BlogMappingExtension
    {
        public static BlogDto ToDto(this Blog blog)
        {
            if (blog == null) return null;

            return new BlogDto
            {
                Id = blog.Id,
                Title = blog.Title,
                Content = blog.Content,
                UserId = blog.UserId,
                User = blog.User != null ? blog.User.ToDto() : null,
                DatePublished = blog.DatePublished,
                ImageUrl = blog.ImageUrl,
                Status = blog.Status.ToString()
            };
        }

        public static Blog ToEntity(this BlogToAddDto blogDto)
        {
            if (blogDto == null) throw new ArgumentNullException(nameof(blogDto));

            return new Blog
            {
                Title = blogDto.Title,
                Content = blogDto.Content,
                UserId = blogDto.UserId,
                DatePublished = DateOnly.FromDateTime(DateTime.Now),
                ImageUrl = blogDto.ImageUrl
            };
        }

        public static void UpdateFromDto(this Blog blog, BlogToUpdateDto blogDto)
        {
            if (blogDto == null) throw new ArgumentNullException(nameof(blogDto));
            if (blog == null) throw new ArgumentNullException(nameof(blog));

            blog.Title = blogDto.Title;
            blog.Content = blogDto.Content;
            blog.Status = (BlogStatus)blogDto.Status;
        }

    }
}
