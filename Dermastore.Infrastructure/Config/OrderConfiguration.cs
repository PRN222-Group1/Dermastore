using Dermastore.Domain.Entities.OrderAggregate;
using Dermastore.Domain.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dermastore.Infrastructure.Config
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.Property(p => p.OrderDate).HasColumnType("datetime");
            builder.Property(p => p.ShippingAddress).HasColumnType("nvarchar(1000)");
            builder.Property(p => p.SubTotal).HasColumnType("decimal(18,2)");

            builder.Property(x => x.Status).HasConversion(
                o => o.ToString(),
                o => (OrderStatus)Enum.Parse(typeof(OrderStatus), o)
            );

            builder.HasOne(o => o.Promotion).WithMany().HasForeignKey(o => o.PromotionId);
            builder.HasMany(o => o.OrderItems).WithOne().OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(o => o.User).WithMany().HasForeignKey(o => o.UserId);
            builder.HasOne(o => o.DeliveryMethod).WithMany().HasForeignKey(o => o.DeliveryMethodId);
        }
    }
}
