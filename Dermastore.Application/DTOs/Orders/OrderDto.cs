using Dermastore.Application.DTOs.AccountDTOs;
using Dermastore.Domain.Enums;

namespace Dermastore.Application.DTOs.Orders
{
    public class OrderDto
    {
        public int Id { get; set; }
        public required DateTime OrderDate { get; set; }
        public string ShippingAddress { get; set; }
        public decimal SubTotal { get; set; }
        public int UserId { get; set; }
        public UserDto? User { get; set; }
        public int? PromotionId { get; set; }
        public PromotionDto? Promotion { get; set; }
        public int? MembershipId { get; set; }
        public MembershipDto? Membership { get; set; }
        public int DeliveryMethodId { get; set; }
        public DeliveryMethodDto? DeliveryMethod { get; set; }
        public string Status { get; set; }
        public List<OrderItemDto> OrderItems { get; set; }
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
