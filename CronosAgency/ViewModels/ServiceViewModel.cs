using System.ComponentModel.DataAnnotations;

namespace CronosAgency.ViewModels
{
    public class ServiceViewModel
    {
        [Required]
        [DataType(DataType.Text)]
        public int Id { get; set; }
        [Required]
        [DataType(DataType.Text)]
        public string Name { get; set; }
        [Required]
        [DataType(DataType.Text)]
        public string Description { get; set; }
    }
}
