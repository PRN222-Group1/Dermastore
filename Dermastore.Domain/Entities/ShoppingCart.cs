namespace Dermastore.Domain.Entities
{
    public class ShoppingCart
    {
        public required string Id { get; set; }
        public List<CartItem> Items { get; set; } = [];
        public Promotion? Promotion { get; set; }
        public DeliveryMethod? DeliveryMethod { get; set; }
    }
}
