using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TestTask.Domain.ModelValidations;

namespace TestTask.Domain.Models
{
    public class Answer
    {
        [Key]
        public int IdAnswer { get; set; }
        [Required]
        [MinLength(3)]
        [MaxLength(300)]
        [Column(TypeName = "varchar(300)")]
        public string Content { get; set; }
        [Required]
        public bool IsCorrect { get; set; }
        [Required]
        public int QuestionId { get; set; }
        public Question? Question { get; set; }
    }
}
