using FitnessTracker.Data.Models;
using FitnessTrackerReal.Data;
using Microsoft.EntityFrameworkCore;

namespace FitnessTrackerReal.Services
{
    public class WorkoutService
    {
        private readonly ApplicationDbContext dbContext;

        public WorkoutService(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<IEnumerable<AllWorkoutsDto>> GetAllWorkoutsAsync()
        {
            return await dbContext.Workouts.Select(w => new AllWorkoutsDto()
            {
                Date = w.Date,
                WorkoutName = w.WorkoutName,
                Id = w.Id,
                Intensity = w.Intensity,
                DurationInSeconds = w.DurationInSeconds,
                ImageUrl = w.ImageUrl,
                Exercises = w.Exercises.Select(e => new ExerciseDto()
                {
                    Description = e.Description,
                    DifficultyLevel = e.DifficultyLevel,
                    Id = e.Id,
                    Name = e.Name,
                }).ToList(),
            }).ToListAsync();
        }
    }
}
