using Dermastore.Domain.Entities.OrderAggregate;

namespace Dermastore.Domain.Entities
{
    public class Feedback : BaseEntity
    {
        public required string Content { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public required DateTime CreatedDate { get; set; } = DateTime.Now;
    }
}
