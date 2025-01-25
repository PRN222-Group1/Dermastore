using Dermastore.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dermastore.Infrastructure.Config
{
    public class FeedbackConfiguration : IEntityTypeConfiguration<Feedback>
    {
        public void Configure(EntityTypeBuilder<Feedback> builder)
        {
            builder.Property(p => p.Content).HasColumnType("nvarchar(1000)");
            builder.Property(p => p.CreatedDate).HasColumnType("date");
            builder.HasOne(f => f.User).WithMany().HasForeignKey(f => f.UserId);
        }
    }
}
