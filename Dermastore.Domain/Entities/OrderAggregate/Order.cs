using Dermastore.Domain.Enums;

namespace Dermastore.Domain.Entities.OrderAggregate
{
    public class Order : BaseEntity
    {
        public required DateTime OrderDate { get; set; }
        public string ShippingAddress { get; set; }
        public List<OrderItem> OrderItems { get; set; }
        public decimal SubTotal { get; set; }
        public string UserId { get; set; }
        public User User { get; set; }
        public int PromotionId { get; set; }
        public Promotion Promotion { get; set; }
        public int DeliveryMethodId { get; set; }
        public DeliveryMethod DeliveryMethod { get; set; }
        public OrderStatus Status { get; set; } = OrderStatus.Pending;
        public decimal GetTotal()
        {
            return SubTotal + DeliveryMethod.Price - (Promotion.Discount * SubTotal);
        }
    }
}
