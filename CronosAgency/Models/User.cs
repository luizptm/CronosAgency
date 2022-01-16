using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

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
        public int RoleId { get; set; }
        [NotMapped]
        [JsonIgnore]
        public virtual Role Role { get; set; }
    }
}
