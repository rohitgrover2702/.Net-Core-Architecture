

using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Kobe.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Kobe.Data.EntityDBMapping;

namespace Kobe.Data.Context
{
    public class KobeContext : IdentityDbContext<ApplicationUser>
    {
        //public DbSet<UserDetail> User { get; set; }       

        public KobeContext(DbContextOptions<KobeContext> options) : base(options)
        {

        }
        public DbSet<Country> Country { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Country>(new CountryMap().Configure);
           // modelBuilder.Entity<UserDetail>(new UserDetailMap().Configure);            
            // ModelBuilderExtensions.Seed(modelBuilder);

        }
    }
}
