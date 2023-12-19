using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WebApp.Common;

namespace FitnessTracker.Data.Entities
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
