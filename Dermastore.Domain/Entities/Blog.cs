namespace Dermastore.Domain.Entities
{
    public class Blog : BaseEntity
    {
        public required string Title { get; set; }
        public required string Content { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public required DateOnly DatePublished { get; set; } = DateOnly.FromDateTime(DateTime.Now);
    }
}
