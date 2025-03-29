namespace Dermastore.Application.DTOs.CartDTOs
{
    public class CartItemDto
    {
        public int ProductId { get; set; }
        public required string ProductName { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public required string ImageUrl { get; set; }
    }
}
