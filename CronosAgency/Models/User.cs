using System;

namespace CronosAgency.Models
{
    public class User
    {
        public int Id { get; set; }
		public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
		public DateTime CreateDate { get; set; }
		public DateTime LastTimePasswordChanged { get; set; }
    }
}
