using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyApp.Web.Api.Bussiness.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyApp.Web.Api.Data.Access
{
    public class EmployeeMap : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnName("id").UseIdentityAlwaysColumn();
            builder.Property(x => x.FirstName).HasColumnName("first_name").HasMaxLength(50).IsRequired();
            builder.Property(x => x.LastName).HasColumnName("last_name").HasMaxLength(50).IsRequired();
            builder.Property(x => x.Email).HasColumnName("email").HasMaxLength(50);
            builder.Property(x => x.DateOfBirth).HasColumnName("data_of_birth").IsRequired();
            builder.Property(x => x.Password).HasColumnName("password").IsRequired();

            builder.ToTable("employees", "public");
        }
    }
}
