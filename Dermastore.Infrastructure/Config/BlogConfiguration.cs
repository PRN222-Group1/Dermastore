using Dermastore.Domain.Entities;
using Dermastore.Domain.Enums;
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
            builder.Property(p => p.Status)
                .HasConversion(
                    s => s.ToString(),
                    s => (BlogStatus)Enum.Parse(typeof(BlogStatus), s))
                .HasColumnType("varchar(50)");
            builder.HasOne(b => b.User).WithMany().HasForeignKey(b => b.UserId);
        }
    }
}
