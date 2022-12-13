using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TestTask.Domain.ModelValidations;

namespace TestTask.Domain.Models
{
    public class User
    {
        [Key]
        public int IdUser { get; set; }
        [Required]
        [MinLength(3)]
        [MaxLength(45)]
        [Column(TypeName = "varchar(45)")]
        public string Username { get; set; }
        [Required]
        [MinLength(7)]
        [MaxLength(37)]
        [Column(TypeName = "varchar(37)")]
        public string Password { get; set; }
        public List<Test> Tests { get; set; } = new();
    }
}
