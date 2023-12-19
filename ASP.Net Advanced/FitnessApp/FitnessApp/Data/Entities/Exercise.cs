using System.ComponentModel.DataAnnotations;

namespace FitnessTracker.Data.Entities
{
    public class Exercise
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = null!;

        [Required]
        public string Description { get; set; } = null!;

        [Required]
        public int DifficultyLevel { get; set; }
    }
}
