namespace Dermastore.Application.DTOs.Orders
{
    public class OrderItemDto
    {
        public ProductItemOrderedDto ItemOrdered { get; set; } = null!;
        public decimal Price { get; set; }
        public int Quantity { get; set; }
    }
}
