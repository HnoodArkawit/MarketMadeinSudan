using MarketMadeinSudan.Domin;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MarketMadeinSudan.Persistence.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<ApplicationUser>
    {
        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            var hasher = new PasswordHasher<ApplicationUser>();
            builder.HasData(
                 new ApplicationUser
                 {
                     Id = "8e445865-a24d-4543-a6c6-9443d048cdb9",
                     FirstName = "System",
                     LastName = "Admin",
                     UserName = "sony",
                     NormalizedUserName = "Sony",
                     Email = "sony@systemdotproject.com",
                     NormalizedEmail = "SONY@SYSTEMDOTPROJECT.COM",
                     EmailConfirmed = true,
                     PasswordHash = hasher.HashPassword(null, "Eka@3zal")
                 }
            );
        }
    }
}
