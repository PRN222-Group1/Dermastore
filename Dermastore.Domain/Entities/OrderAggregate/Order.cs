using Dermastore.Domain.Enums;

namespace Dermastore.Domain.Entities.OrderAggregate
{
    public class Order : BaseEntity
    {
        public required DateTime OrderDate { get; set; }
        public string ShippingAddress { get; set; }
        public decimal SubTotal { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public int? PromotionId { get; set; }
        public Promotion? Promotion { get; set; }
        public int? MembershipId { get; set; }
        public Membership? Membership { get; set; }
        public int DeliveryMethodId { get; set; }
        public DeliveryMethod DeliveryMethod { get; set; }
        public OrderStatus Status { get; set; } = OrderStatus.Pending;
        public List<OrderItem> OrderItems { get; set; }
        public decimal GetTotal()
        {
            decimal promoDiscount = 0;
            decimal membershipDiscount = 0;
            decimal deliveryPrice = 0;

            if (Promotion != null)
            {
                promoDiscount = Promotion.Discount;
            }

            if (Membership != null)
            {
                membershipDiscount = Membership.Discount;
            }

            if (DeliveryMethod != null)
            {
                deliveryPrice = DeliveryMethod.Price;
            }

            return SubTotal + deliveryPrice - ((promoDiscount + membershipDiscount) * SubTotal);
        }
    }
}
