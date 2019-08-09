using Kobe.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Kobe.Data.EntityDBMapping
{
    public class UserDetailMap : EntityBaseMap<KobeUser>
    {
        public new void Configure(EntityTypeBuilder<KobeUser> builder)
        {
            builder.ToTable("KobeUser");          
            builder.Property(c => c.Username)
                .IsRequired()
                .HasColumnName("Username")
                .HasColumnType("varchar(150)");
            builder.Property(c => c.Email)
               .IsRequired()
               .HasColumnName("Email")
               .HasColumnType("varchar(150)");
            builder.Property(c => c.HashedPassword)
               .IsRequired()
               .HasColumnName("HashedPassword")
               .HasColumnType("binary(128)");
            builder.Property(c => c.Salt)
               .IsRequired()
               .HasColumnName("Salt")
               .HasColumnType("binary(128)");
            builder.Property(c => c.Token)             
              .HasColumnName("Token")
              .HasColumnType("varchar(150)");
            builder.Property(c => c.TokenExpiryDate)            
              .HasColumnName("TokenExpiryDate")
              .HasColumnType("DateTime");
            builder.Property(c => c.IsLocked)
              .IsRequired()
              .HasColumnName("IsLocked")
              .HasColumnType("bit");
            builder.Property(c => c.IsDeactivated)
              .IsRequired()
              .HasColumnName("IsDeactivated")
              .HasColumnType("bit");
        }
    }
}
