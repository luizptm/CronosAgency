using CronosAgency.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CronosAgency.ViewModel
{
    public class RoleViewModel
    {
        [Required]
        [DataType(DataType.Text)]
        public string Id { get; set; }
        [Required]
        [Display(Name = "Role")]
        public string Name { get; set; }

        public virtual List<string> Users { get; set; }
    }
}
