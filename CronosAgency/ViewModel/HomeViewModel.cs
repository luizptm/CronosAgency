using CronosAgency.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CronosAgency.ViewModel
{
    public class HomeViewModel
    {
        public List<Service> Services { get; set; }
        public List<Post> Posts { get; set; }
        public List<Member> Members { get; set; }
    }
}
