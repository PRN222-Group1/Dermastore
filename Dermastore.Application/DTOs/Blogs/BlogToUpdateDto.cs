namespace Dermastore.Application.DTOs.Blogs
{
    public class BlogToUpdateDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string? ImageUrl { get; set; }
        public int Status { get; set; }
    }
}
