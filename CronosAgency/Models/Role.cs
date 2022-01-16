using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace CronosAgency.Models
{
    public class Role : IdentityRole
    {
        public virtual List<string> Users { get; set; }
    }
}