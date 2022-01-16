using Microsoft.AspNetCore.Identity;

namespace CronosAgency.Models
{
    public class ApplicationUser : User
    {
        public string Country { get; set; }

        public string City { get; set; }

        public string District { get; set; }
    }
}