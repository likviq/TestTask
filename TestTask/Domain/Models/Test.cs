using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TestTask.Domain.ModelValidations;

namespace TestTask.Domain.Models
{
    public class Test
    {
        [Key]
        public int IdTest { get; set; }
        [Required]
        [MinLength(3)]
        [MaxLength(150)]
        [Column(TypeName = "varchar(150)")]
        public string Description { get; set; }
        [Required]
        [MinLength(3)]
        [MaxLength(40)]
        [Column(TypeName = "varchar(40)")]
        public string Title { get; set; }
        public int CreatorId { get; set; }
        public List<Question> Questions { get; set; } = new();
        public List<User> Users { get; set; } = new();
    }
}
