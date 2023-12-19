using System.ComponentModel.DataAnnotations;

namespace WebApp.Data.Models
{
    public class Exercise
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(Common.ExerciseNameMaxLenght)]
        public string Name { get; set; } = null!;

        [Required]
        public string Description { get; set; } = null!;

        [Required]
        public int DifficultyLevel { get; set; }
    }
}
