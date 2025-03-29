namespace Dermastore.Application.DTOs.AccountDTOs
{
    public class UserDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public int Point {  get; set; }
        public string ImageUrl { get; set; }
        public MembershipDto? Membership { get; set; }
        public string Status { get; set; }
    }
}
