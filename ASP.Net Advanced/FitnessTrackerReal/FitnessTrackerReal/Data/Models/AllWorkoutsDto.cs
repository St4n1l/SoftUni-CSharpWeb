using FitnessTracker.Data.Entities;
using System.ComponentModel.DataAnnotations;

namespace FitnessTracker.Data.Models
{
    public class AllWorkoutsDto
    {
        public AllWorkoutsDto()
        {
            Exercises = new List<ExerciseDto>(); 
        }

        [Key]
        public int Id { get; set; }

        public string WorkoutName { get; set; } = null!;

        public int DurationInSeconds { get; set; }

        public int Intensity { get; set; }

        public DateTime Date { get; set; }

        public ICollection<ExerciseDto> Exercises { get; set; }

        public string ImageUrl { get; set; } = null!;
    }
  
}
