using Dermastore.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dermastore.Infrastructure.Config
{
    public class QuestionConfiguration : IEntityTypeConfiguration<Question>
    {
        public void Configure(EntityTypeBuilder<Question> builder)
        {
            builder.HasMany(q => q.Answers).WithOne();
            builder.Property(q => q.Content).HasColumnType("nvarchar(1000)");
        }
    }
}
