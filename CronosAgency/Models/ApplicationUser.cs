using Microsoft.AspNetCore.Identity;

namespace CronosAgency.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string Country { get; set; }
    }
}