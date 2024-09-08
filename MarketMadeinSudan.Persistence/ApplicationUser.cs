
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace MarketMadeinSudan.Persistence
{
    public class ApplicationUser  : IdentityUser
    {
        [Required, MaxLength(100)]
        public string FirstName { get; set; } = "default value";

        [Required, MaxLength(100)]
        public string LastName { get; set; } = "default value";

        //[Required, MaxLength(150)]
        //public string Country { get; set; } = "default value";

        //[Required, MaxLength(250)]
        //public string Address { get; set; } = "default value";

        //[Required, MaxLength(250)]
        //public string City { get; set; } = "default value";

        //[Required]
        //public int Zip { get; set; }

        //public byte[] ProfilePicture { get; set; }
    }
}