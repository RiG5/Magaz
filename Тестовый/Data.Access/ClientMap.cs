using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyApp.Web.Api.Bussiness.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyApp.Web.Api.Data.Access
{
    public class ClientsMap : IEntityTypeConfiguration<Client>
    {
        public void Configure(EntityTypeBuilder<Client> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnName("id").UseIdentityAlwaysColumn();
            builder.Property(x => x.ClientName).HasColumnName("client_name").HasMaxLength(50).IsRequired();
            builder.Property(x => x.ClientAddress).HasColumnName("client_address").HasMaxLength(100).IsRequired();
            builder.Property(x => x.Phone).HasColumnName("phone").HasMaxLength(16);

            builder.ToTable("clients", "public");
        }
    }
}