namespace Dermastore.Application.DTOs
{
    public class MembershipDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int MinPoint { get; set; }
        public decimal Discount { get; set; } = 0;
    }
}
