namespace Dermastore.Application.DTOs
{
    public class MembershipDto
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required int MinPoint { get; set; }
        public required decimal Discount { get; set; } = 0;
    }
}
