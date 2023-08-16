using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyApp.Web.Api.Bussiness.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace MyApp.Web.Api.Data.Access
{
    public class OrdersMap : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnName("id").UseIdentityAlwaysColumn();
            builder.Property(x => x.IdClient).HasColumnName("id_client").IsRequired();
            builder.Property(x => x.IdEmployee).HasColumnName("id_employee").IsRequired();
            builder.Property(x => x.DateOrder).HasColumnName("date_order").IsRequired();
            builder.Property(x => x.State).HasColumnName("state").IsRequired();

            builder.ToTable("orders", "public");
        }
    }
}
