using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyApp.Web.Api.Bussiness.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace MyApp.Web.Api.Data.Access
{
    public class OrderItemsMap : IEntityTypeConfiguration<OrderItem>
    {
        public void Configure(EntityTypeBuilder<OrderItem> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnName("id").UseIdentityAlwaysColumn();
            builder.Property(x => x.IdOrder).HasColumnName("id_order").HasMaxLength(50).IsRequired();
            builder.Property(x => x.IdProduct).HasColumnName("id_product").IsRequired();
            builder.Property(x => x.Quantity).HasColumnName("quantity").IsRequired();
            builder.Property(x => x.Amount).HasColumnName("amount").HasMaxLength(20)/*HasMaxLength(18,2)*/.IsRequired();
            builder.Property(x => x.Price).HasColumnName("price").HasMaxLength(20)/*HasMaxLength(18,2)*/.IsRequired();

            builder.ToTable("order_items", "public");
        }
    }
}