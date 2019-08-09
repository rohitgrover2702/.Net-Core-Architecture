using Kobe.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Collections.Generic;
using System.Text;

namespace Kobe.Data.EntityDBMapping
{
    public class CountryMap : EntityBaseMap<KobeCountry>
    {
        public new void Configure(EntityTypeBuilder<KobeCountry> builder)
        {
            builder.ToTable("KobeCountry");
            builder.Property(c => c.Name)
                .IsRequired()
                .HasColumnName("Name")
                .HasColumnType("varchar(150)");          
            builder.Property(c => c.Capital)
               .IsRequired()
               .HasColumnName("Capital")
               .HasColumnType("varchar(150)");            
        }
    }
}
