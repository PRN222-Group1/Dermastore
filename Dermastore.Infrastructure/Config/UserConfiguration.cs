using Dermastore.Domain.Entities;
using Dermastore.Domain.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dermastore.Infrastructure.Config
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("User");

            builder.HasIndex(u => u.PhoneNumber).IsUnique();
            builder.HasIndex(u => u.Email).IsUnique();

            builder.Property(u => u.FirstName).HasColumnType("nvarchar(100)");
            builder.Property(u => u.LastName).HasColumnType("nvarchar(100)");
            builder.Property(u => u.LastName).HasColumnType("nvarchar(100)");

            builder.Property(x => x.Status).HasConversion(
                u => u.ToString(),
                u => (UserStatus)Enum.Parse(typeof(UserStatus), u)
            );

            builder.Property(x => x.Gender).HasConversion(
                u => u.ToString(),
                u => (Gender)Enum.Parse(typeof(Gender), u)
            );

            builder.Property(u => u.Address).HasColumnType("nvarchar(1000)");
            builder.Property(u => u.ImageUrl).HasColumnType("nvarchar(200)");
            builder.HasOne(u => u.Membership).WithMany().HasForeignKey(u => u.MembershipId);
        }
    }
}
