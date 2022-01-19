using CronosAgency.Models;
using System.Collections.Generic;

namespace CronosAgency.ViewModels
{
    public class HomeViewModel
    {
        public List<Service> Services { get; set; }
        public List<Post> Posts { get; set; }
        public List<Member> Members { get; set; }
    }
}
