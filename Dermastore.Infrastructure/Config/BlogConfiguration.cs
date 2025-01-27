using Dermastore.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dermastore.Infrastructure.Config
{
    public class BlogConfiguration : IEntityTypeConfiguration<Blog>
    {
        public void Configure(EntityTypeBuilder<Blog> builder)
        {
            builder.Property(p => p.Title).HasColumnType("nvarchar(200)");
            builder.Property(p => p.Content).HasColumnType("nvarchar(1000)");
            builder.Property(p => p.DatePublished).HasColumnType("date");
            builder.HasOne(b => b.User).WithMany().HasForeignKey(b => b.UserId);
        }
    }
}
