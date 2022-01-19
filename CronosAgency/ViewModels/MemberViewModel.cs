using System.ComponentModel.DataAnnotations;

namespace CronosAgency.ViewModels
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

        public override string ToString()
        => $"{Name.Trim()} {Surname.Trim()}";
    }
}
