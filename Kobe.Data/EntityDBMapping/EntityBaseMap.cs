using Kobe.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;


namespace Kobe.Data.EntityDBMapping
{
    public class EntityBaseMap<T> :  IEntityTypeConfiguration<T> where T : class, BaseEntity
    {
        
        public void Configure(EntityTypeBuilder<T> builder)
        {
            
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).IsRequired().HasColumnName(@"ID").HasColumnType("Guid");
            builder.Property(x => x.CreatedBy).IsRequired().HasColumnName(@"CreatedBy").HasColumnType("varchar(150)");
            builder.Property(x => x.CreatedDate).IsRequired().HasColumnName(@"CreatedDate").HasColumnType("datetime");
            builder.Property(x => x.ModifiedDate).IsRequired().HasColumnName(@"ModifiedDate").HasColumnType("datetime");
            builder.Property(x => x.IsDeleted).HasColumnName(@"IsDeleted").HasColumnType("bool");
        }
    }
}
