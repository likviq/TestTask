using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TestTask.Domain.Models
{
    public class Questions
    {
        public int IdQuestion { get; set; }
        [Required]
        [MaxLength(300)]
        [Column(TypeName = "varchar(300)")]
        public string? Question { get; set; }
        [Required]
        public int Mark { get; set; }
    }
}
