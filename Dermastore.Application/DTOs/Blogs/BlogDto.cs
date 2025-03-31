using Dermastore.Application.DTOs.AccountDTOs;

namespace Dermastore.Application.DTOs.Blogs
{
    public class BlogDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public int UserId { get; set; }
        public UserDto? User { get; set; }
        public required DateOnly DatePublished { get; set; }
        public string? ImageUrl { get; set; }
        public string Status { get; set; }
    }
}

