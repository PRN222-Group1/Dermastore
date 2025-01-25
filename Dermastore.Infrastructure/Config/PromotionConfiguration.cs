using Dermastore.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dermastore.Infrastructure.Config
{
    public class PromotionConfiguration : IEntityTypeConfiguration<Promotion>
    {
        public void Configure(EntityTypeBuilder<Promotion> builder)
        {
            builder.Property(p => p.Name).HasColumnType("nvarchar(200)");
            builder.Property(p => p.ExpiryDate).HasColumnType("date");
            builder.Property(p => p.EffectiveDate).HasColumnType("date");
            builder.Property(p => p.Discount).HasColumnType("decimal(5,2)");
            builder.Property(p => p.Code).HasColumnType("varchar(100)");
            builder.Property(p => p.Status).HasColumnType("varchar(50)");
        }
    }
}
