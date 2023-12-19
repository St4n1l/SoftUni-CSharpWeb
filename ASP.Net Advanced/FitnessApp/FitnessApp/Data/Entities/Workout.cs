using System.ComponentModel.DataAnnotations;
using static FitnessTracker.Data.Common;

namespace FitnessTracker.Data.Entities
{
    public class Workout
    {
        public Workout()
        {
            Exercises = new List<Exercise>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(Common.WorkoutNameMaxLenght)]
        public string WorkoutName { get; set; } = null!;

        [Required]
        public int DurationInSeconds { get; set; }

        [Required]
        public int Intensity { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [Required]
        public ICollection<Exercise> Exercises { get; set; }

        [Required]
        public string ImageUrl { get; set; } = null!;
    }
}
