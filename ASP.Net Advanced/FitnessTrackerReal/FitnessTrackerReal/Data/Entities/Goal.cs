using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FitnessTracker.Data.Entities
{
    public class Goal
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey(nameof(UserId))]
        public int UserId { get; set; }
        public User User { get; set; } = null!;

        [Required]        
        public decimal TargetWeight { get; set; }

        [Required]
        public int TargetSteps { get; set; }

        [Required]
        public int TargetExerciseFrequencyPerWeek { get; set; }
    }
}
