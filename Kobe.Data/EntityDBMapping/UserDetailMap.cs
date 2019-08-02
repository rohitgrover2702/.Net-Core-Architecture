using Kobe.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Kobe.Data.EntityDBMapping
{
    public class UserDetailMap : EntityBaseMap<UserDetail>
    {
        public new void Configure(EntityTypeBuilder<UserDetail> builder)
        {
            builder.ToTable("UserDetail");          
            builder.Property(c => c.FirstName)
                .IsRequired()
                .HasColumnName("FirstName")
                .HasColumnType("varchar(150)");
            builder.Property(c => c.FirstName)
               .IsRequired()
               .HasColumnName("LastName")
               .HasColumnType("varchar(150)");
            builder.Property(c => c.LastName)
               .IsRequired()
               .HasColumnName("Email")
               .HasColumnType("varchar(150)");
            builder.Property(c => c.Email)
               .IsRequired()
               .HasColumnName("Password")
               .HasColumnType("varchar(150)");
        }
    }
}
