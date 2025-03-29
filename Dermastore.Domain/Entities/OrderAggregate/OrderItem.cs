namespace Dermastore.Domain.Entities.OrderAggregate
{
    public class OrderItem : BaseEntity
    {
        public ProductItemOrdered ItemOrdered { get; set; } = null!;
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public int? FeedbackId { get; set; }
        public Feedback? Feedback { get; set; }
    }
}
