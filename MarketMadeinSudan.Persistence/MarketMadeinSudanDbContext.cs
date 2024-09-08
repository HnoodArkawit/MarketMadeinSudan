using MarketMadeinSudan.Domin;
using MarketMadeinSudan.Persistence.Configurations;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace MarketMadeinSudan.Persistence
{
    public class MarketMadeinSudanDbContext : IdentityDbContext<ApplicationUser>
    {
        public MarketMadeinSudanDbContext(DbContextOptions<MarketMadeinSudanDbContext> options)
    : base(options)
        {
        }

        public DbSet<Accessories> Accessoriess { get; set; }
        public DbSet<AgriculturalCrops> AgriculturalCropss { get; set; }
        public DbSet<Aspires> Aspires { get; set; }
        public DbSet<ElectricalAndElctronic> ElectricalAndElctronics { get; set; }
        public DbSet<Fabrics> Fabricss { get; set; }
        public DbSet<Food> Foods { get; set; }
        public DbSet<HouseholdProducts> HouseholdProductss { get; set; }
        public DbSet<Other> Others { get; set; }
        public DbSet<SportAndEntertainment> SportAndEntertainments { get; set; }
        public DbSet<WatchesAndJewelry> WatchesAndJewelrys { get; set; }
        public DbSet<Publishers> Publisherss { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<OrderDetails> OrderDetailss { get; set; }
        public DbSet<Advertisements> Advertisementss { get; set; }
        public DbSet<Shipping> Shippings { get; set; }

        //public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new RoleConfiguration());
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new UserRoleConfiguration());
        }

    }

}
