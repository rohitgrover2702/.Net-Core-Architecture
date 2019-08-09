

using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Kobe.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Kobe.Data.EntityDBMapping;

namespace Kobe.Data.Context
{
    public class KobeContext : DbContext
    {        

        public KobeContext(DbContextOptions<KobeContext> options) : base(options)
        {

        }
        public DbSet<KobeCountry> Country { get; set; }
        public DbSet<KobeUser> User { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<KobeCountry>(new CountryMap().Configure);
            modelBuilder.Entity<KobeUser>(new UserDetailMap().Configure);            
            // ModelBuilderExtensions.Seed(modelBuilder);

        }
    }
}
