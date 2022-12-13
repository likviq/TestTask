using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TestTask.Domain.Models
{
    public class Question
    {
        [Key]
        public int IdQuestion { get; set; }
        [Required]
        [MinLength(10)]
        [MaxLength(300)]
        [Column(TypeName = "varchar(300)")]
        public string? Content { get; set; }
        [Required]
        public int Mark { get; set; }
        public List<Answer> Answers { get; set; } = new();
        public int TestId { get; set; }
        public Test? Tests { get; set; }
    }
}
