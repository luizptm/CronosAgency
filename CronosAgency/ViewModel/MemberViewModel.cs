using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace CronosAgency.ViewModel
{
    public class MemberViewModel
    {
        [Required]
        [DataType(DataType.Text)]
        public int Id { get; set; }
        [Required]
        [DataType(DataType.Text)]
        public string Name { get; set; }
        [Required]
        [DataType(DataType.Text)]
        public string Surname { get; set; }
    }
}
