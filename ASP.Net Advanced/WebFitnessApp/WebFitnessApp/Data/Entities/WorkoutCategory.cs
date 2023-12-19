using System.ComponentModel.DataAnnotations;

namespace WebFitnessApp.Data.Entities
{
    public class WorkoutCategory
    {
        public WorkoutCategory()
        {
            Workouts = new List<Workout>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(Common.Category.NameMaxLength)]
        public string Name { get; set; } = null!;

        public virtual ICollection<Workout> Workouts { get; set; }
    }
}
