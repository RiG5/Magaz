using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyApp.Web.Api.Bussiness.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace MyApp.Web.Api.Data.Access
{
    public class ProductsMap : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnName("id").UseIdentityAlwaysColumn();
            builder.Property(x => x.ProductName).HasColumnName("product_name").HasMaxLength(50).IsRequired();
            builder.Property(x => x.Category).HasColumnName("category").IsRequired();
            builder.Property(x => x.Price).HasColumnName("price").HasMaxLength(18,2).IsRequired();

            builder.ToTable("products", "public");
        }
    }
}