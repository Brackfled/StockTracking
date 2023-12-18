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
    public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.ToTable("Customers").HasKey(c=>c.Id);

            builder.Property(s => s.Id).HasColumnName("Id").IsRequired();
            builder.Property(s => s.Name).HasColumnName("Name").IsRequired();
            builder.Property(s => s.CompanyName).HasColumnName("CompanyName").IsRequired();
            builder.Property(s => s.PhoneNumber).HasColumnName("PhoneNumber").IsRequired();
            builder.Property(s => s.Email).HasColumnName("Email").IsRequired();
            builder.Property(s => s.Adress).HasColumnName("Adress").IsRequired();

            builder.Property(b => b.CreatedDate).HasColumnName("CreatedDate").IsRequired();
            builder.Property(b => b.UpdatedDate).HasColumnName("UpdatedDate");
            builder.Property(b => b.DeletedDate).HasColumnName("DeletedDate");

            builder.HasIndex(indexExpression: s => s.Name, name: "UK_Sellers_Name").IsUnique();

            builder.HasQueryFilter(s => !s.DeletedDate.HasValue);
        }
    }
}
