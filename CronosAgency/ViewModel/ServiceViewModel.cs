using System.ComponentModel.DataAnnotations;

namespace CronosAgency.ViewModel
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
