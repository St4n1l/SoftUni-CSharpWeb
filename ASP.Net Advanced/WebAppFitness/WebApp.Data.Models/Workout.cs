using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static FitnessTracker.Data.Common;

namespace WebApp.Data.Models
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
        public string Description { get; set; }

        [Required]
        public int DurationInMinutes { get; set; }

        [Required]
        public int Intensity { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [Required]
        public virtual ICollection<Exercise> Exercises { get; set; }

        public string? ImageUrl { get; set; } = null!;

        [Required]
        [ForeignKey(nameof(Category))]
        public int CategoryId { get; set; }

        [Required]
        public WorkoutCategory Category { get; set; }
    }
}
