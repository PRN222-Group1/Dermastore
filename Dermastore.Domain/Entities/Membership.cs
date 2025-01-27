namespace Dermastore.Domain.Entities
{
    public class Membership : BaseEntity
    {
        public required string Name { get; set; }
        public required int MinPoint { get; set; }
        public required decimal Discount { get; set; } = 0;
    }
}
