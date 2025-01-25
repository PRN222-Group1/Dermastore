using Dermastore.Core.Entities.OrderAggregate;

namespace Dermastore.Core.Entities
{
    public class Feedback : BaseEntity
    {
        public required string Content { get; set; }
        public string UserId { get; set; }
        public User User { get; set; }
        public required DateTime CreatedDate { get; set; } = DateTime.Now;
    }
}
