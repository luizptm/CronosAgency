using System;
using System.ComponentModel.DataAnnotations;

namespace CronosAgency.ViewModels
{
    public class RegisterViewModel
    {
        [Required]
        [DataType(DataType.Text)]
        public int Id { get; set; }
        [Required]
        [DataType(DataType.Text)]
        public string Name { get; set; }
        [Required]
        [DataType(DataType.Text)]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Text)]
        public string Password { get; set; }
        [Required]
        [DataType(DataType.Text)]
        public string ConfirmPassword { get; set; }
        [Required]
        [DataType(DataType.DateTime)]
        public DateTime CreateDate { get; set; }
        [Required]
        [DataType(DataType.DateTime)]
        public DateTime LastTimePasswordChanged { get; set; }
    }
}
