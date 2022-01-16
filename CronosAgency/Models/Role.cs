using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace CronosAgency.Models
{
    public class Role
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string NormalizedName { get; set; }
        [NotMapped]
        [JsonIgnore]
        public List<string> Users { get; set; }
    }
}