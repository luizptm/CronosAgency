using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace CronosAgency.ViewModel
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "O email é obrigatório")]
        [EmailAddress(ErrorMessage = "Email inválido")]
        [Remote(action: "IsEmailInUse", controller: "Account")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [HiddenInput]
        public string ReturnUrl { get; set; }
    }
}
