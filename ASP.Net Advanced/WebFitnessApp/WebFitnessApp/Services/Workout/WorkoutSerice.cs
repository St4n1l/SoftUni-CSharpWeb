using Microsoft.EntityFrameworkCore;
using WebFitnessApp.Contracts;
using WebFitnessApp.Data;
using WebFitnessApp.Data.ViewModels;

namespace WebFitnessApp.Services.Workout
{
    public class WorkoutSerice : IWorkoutService
    {
        private readonly ApplicationDbContext _data;

        public WorkoutSerice(ApplicationDbContext data)
        {
            _data = data;
        }

        public async Task<IEnumerable<WorkoutIndexServiceModel>> LastThreeWorkouts()
        {
            return await _data
                .Workouts
                .OrderByDescending(w => w.Id)
                .Select(x => new WorkoutIndexServiceModel
                {
                    Id = x.Id,
                    Name = x.WorkoutName,
                    ImageUrl = x.ImageUrl
                })
                .Take(3)
                .ToListAsync();           

        }

    }
}
