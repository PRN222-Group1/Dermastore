﻿using Dermastore.Domain.Entities;
using Dermastore.Domain.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dermastore.Infrastructure.Config
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.Property(p => p.Name).HasColumnType("nvarchar(200)");
            builder.Property(p => p.Description).HasColumnType("nvarchar(1000)");
            builder.Property(p => p.Price).HasColumnType("decimal(18,2)");
            builder.Property(p => p.ImageUrl).HasColumnType("varchar(600)");
            builder.Property(p => p.Status)
                .HasConversion(
                    s => s.ToString(),
                    s => (ProductStatus)Enum.Parse(typeof(ProductStatus), s))
                .HasColumnType("varchar(50)");

            builder.HasOne(p => p.SubCategory).WithMany().HasForeignKey(p => p.SubCategoryId);
            builder.HasOne(p => p.Answer).WithMany(p => p.Products).HasForeignKey(p => p.AnswerId);
            builder.HasOne(p => p.Brand).WithMany().HasForeignKey(p => p.BrandId);
        }
    }
}
