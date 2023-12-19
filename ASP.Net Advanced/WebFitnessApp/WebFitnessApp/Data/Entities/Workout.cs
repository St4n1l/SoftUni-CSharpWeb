using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebFitnessApp.Data.Entities
{
    public class Workout
    {
        public Workout()
        {
            Exercises = new List<Exercise>();

            Users = new List<ApplicationUser>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(Common.Workout.NameMaxLength)]
        public string WorkoutName { get; set; } = null!;

        [Required]
        [MaxLength(Common.Workout.DescriptionMaxLength)]
        public string Description { get; set; } = null!;

        [Required]
        [MaxLength(Common.Workout.DurationMaxValue)]
        public int DurationInSeconds { get; set; }

        [Required]
        [MaxLength(Common.Workout.IntensityMaxLevel)]
        public int Intensity { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [Required]
        public virtual ICollection<Exercise> Exercises { get; set; }

        [Required]
        [MaxLength(Common.Workout.ImageUrlMaxLength)]
        public string ImageUrl { get; set; } = null!;

        [Required]
        [ForeignKey(nameof(Category))]
        public int CategoryId { get; set; }

        [Required]
        public WorkoutCategory Category { get; set; } = null!;

        public virtual ICollection<ApplicationUser> Users { get; set; } = null!;
    }
}
