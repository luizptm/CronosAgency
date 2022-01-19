using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace CronosAgency.Models
{
    public class Service
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
