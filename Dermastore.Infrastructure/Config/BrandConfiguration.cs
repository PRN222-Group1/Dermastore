using Dermastore.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dermastore.Infrastructure.Config
{
    public class BrandConfiguration : IEntityTypeConfiguration<Brand>
    {
        public void Configure(EntityTypeBuilder<Brand> builder)
        {
            builder.Property(c => c.Name).HasColumnType("nvarchar(200)");
            builder.Property(c => c.Description).HasColumnType("nvarchar(1000)");
        }
    }
}
