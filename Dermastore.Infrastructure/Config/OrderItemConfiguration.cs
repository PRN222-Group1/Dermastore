using Dermastore.Domain.Entities.OrderAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dermastore.Infrastructure.Config
{
    public class OrderItemConfiguration : IEntityTypeConfiguration<OrderItem>
    {
        public void Configure(EntityTypeBuilder<OrderItem> builder)
        {
            builder.OwnsOne(x => x.ItemOrdered, o =>
            {
                o.Property(p => p.ProductName).HasColumnType("nvarchar(200)");
                o.Property(p => p.ImageUrl).HasColumnType("varchar(200)");
                o.WithOwner();
            });
            builder.HasOne(x => x.Feedback).WithOne().HasForeignKey<OrderItem>(x => x.FeedbackId);
            builder.Property(x => x.Price).HasColumnType("decimal(18,2)");
        }
    }
}
