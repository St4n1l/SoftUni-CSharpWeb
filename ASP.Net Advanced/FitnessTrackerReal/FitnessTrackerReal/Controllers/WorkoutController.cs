using FitnessTrackerReal.Services;
using Microsoft.AspNetCore.Mvc;

namespace FitnessTrackerReal.Controllers
{
    public class WorkoutController : BaseController
    {
        private readonly WorkoutService workoutService;

        public WorkoutController(WorkoutService workoutService)
        {
            this.workoutService = workoutService;
        }

        public async Task<IActionResult> AllWorkouts()
        {
            var model = await workoutService.GetAllWorkoutsAsync();
            return View(model);
        }
    }
}
