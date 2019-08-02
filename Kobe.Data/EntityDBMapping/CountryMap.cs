using Kobe.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Collections.Generic;
using System.Text;

namespace Kobe.Data.EntityDBMapping
{
    public class CountryMap : EntityBaseMap<Country>
    {
        public new void Configure(EntityTypeBuilder<Country> builder)
        {
            builder.ToTable("CountryRohit");
            builder.Property(c => c.Name)
                .IsRequired()
                .HasColumnName("Name")
                .HasColumnType("varchar(150)");
            builder.Property(c => c.Population)
               .IsRequired()
               .HasColumnName("Population")
               .HasColumnType("varchar(150)");
            builder.Property(c => c.DrivingSide)
               .IsRequired()
               .HasColumnName("DrivingSide")
               .HasColumnType("varchar(150)");
            builder.Property(c => c.Capital)
               .IsRequired()
               .HasColumnName("Capital")
               .HasColumnType("varchar(150)");
            builder.Property(c => c.Area)
               .IsRequired()
               .HasColumnName("Area")
               .HasColumnType("varchar(150)");
        }
    }
}
