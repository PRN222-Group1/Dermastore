using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dermastore.Infrastructure.Config
{
    public class RoleConfiguration : IEntityTypeConfiguration<IdentityRole>
    {
        public void Configure(EntityTypeBuilder<IdentityRole> builder)
        {
            builder.HasData(
                new IdentityRole { Id = "e7a8c4b7-2c5a-4c5a-9b47-1e1f87289b2b", Name = "Manager", NormalizedName = "MANAGER" },
                new IdentityRole { Id = "f2a5f3d7-3b6c-4c5b-9b2e-1c5e53e4d3f4", Name = "Customer", NormalizedName = "CUSTOMER" },
                new IdentityRole { Id = "d8a7c3a6-1d6f-4b3b-b431-68e6bc953d1e", Name = "Staff", NormalizedName = "STAFF" }
            );
        }
    }
}
