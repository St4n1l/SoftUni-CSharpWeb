using System.ComponentModel.DataAnnotations;

namespace WebFitnessApp.Data.Entities
{

    public class Exercise
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(Common.Exercise.NameMaxLength)]
        public string Name { get; set; } = null!;

        [Required]
        [MaxLength(Common.Exercise.DescriptionMaxLength)]
        public string Description { get; set; } = null!;

        [Required]
        [MaxLength(Common.Exercise.DifficultyLevelMaxLevel)]
        public int DifficultyLevel { get; set; }
    }
}
