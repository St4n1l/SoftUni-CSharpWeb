using FitnessTracker.Data.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAppFitness.Data;

namespace WebAppFitness.Controllers
{
    public class WorkoutController : Controller
    {
        private readonly ApplicationDbContext dbContext;

        public WorkoutController(ApplicationDbContext dbContext)
        {
           this.dbContext = dbContext;
        }

        public IActionResult AllWorkouts()
        {
            List<Workout> workouts = dbContext.Workouts.ToList();
            return View(workouts);
        }
    }
}
