using FactoryPatternDemo.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FactoryPatternDemo.DAL
{
    //public class FactoryDBContext:IdentityDbContext<IdentityUser><-was default//
    //Identity user has many properties, so we created a new class to take some if not all properties

    public class FactoryDBContext:IdentityDbContext<AppUser>
    {
        public FactoryDBContext() { }
        public FactoryDBContext(DbContextOptions<FactoryDBContext>options):base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Animal>()
             .HasDiscriminator<string>("AnimalType")
             .HasValue<Lion>("Lion")
             .HasValue<Elephant>("Elephant");
            modelBuilder.Entity<IdentityUserRole<string>>().HasKey(x=>x.UserId);
            modelBuilder.Entity<IdentityUserLogin<string>>().HasKey(x => x.UserId);
            modelBuilder.Entity<IdentityUserToken<string>>().HasKey(x => x.UserId);

        }
        public DbSet<Animal>Animals { get; set; }
        public DbSet<Lion> Lions { get; set; }
        public DbSet<Elephant> Elephants { get; set; }

    }
}
