using Dermastore.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dermastore.Infrastructure.Config
{
    public class MembershipConfiguration : IEntityTypeConfiguration<Membership>
    {
        public void Configure(EntityTypeBuilder<Membership> builder)
        {
            builder.Property(p => p.Name).HasColumnType("nvarchar(50)");
            builder.Property(p => p.Discount).HasColumnType("decimal(5,2)");
        }
    }
}
