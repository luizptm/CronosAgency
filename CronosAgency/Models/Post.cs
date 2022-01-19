using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace CronosAgency.Models
{
    public class Post
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
    }
}
