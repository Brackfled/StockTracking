using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistance.EntityConfigurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Products").HasKey(p=>p.Id);

            builder.Property(p=> p.Id).HasColumnName("Id").IsRequired();
            builder.Property(p=> p.Name).HasColumnName("Name").IsRequired();
            builder.Property(p=> p.BrandId).HasColumnName("BrandId").IsRequired();
            builder.Property(p => p.SellerId).HasColumnName("SellerId").IsRequired();
            builder.Property(p => p.ProductDetail).HasColumnName("ProductDetail").IsRequired();
            builder.Property(p => p.StockAmount).HasColumnName("StockAmount").IsRequired();
            builder.Property(b => b.CreatedDate).HasColumnName("CreatedDate").IsRequired();
            builder.Property(b => b.UpdatedDate).HasColumnName("UpdatedDate");
            builder.Property(b => b.DeletedDate).HasColumnName("DeletedDate");

            builder.HasIndex(indexExpression: p => p.Name, name: "UK_Products_Name").IsUnique();

            builder.HasOne(p=>p.Brand);
            builder.HasOne(p => p.Seller);

            builder.HasQueryFilter(p =>!p.DeletedDate.HasValue);
        }
    }
}
