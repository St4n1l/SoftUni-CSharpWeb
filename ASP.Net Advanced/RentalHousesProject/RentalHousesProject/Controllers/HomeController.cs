using Microsoft.AspNetCore.Mvc;
using FitnessTracker.Models;
using System.Diagnostics;
using FitnessTracker.Data;
using Microsoft.EntityFrameworkCore;
using FitnessTracker.Data.Models;

namespace FitnessTracker.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext dbContext;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
            this.dbContext = dbContext;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AllWorkouts()
        {
            var workouts = dbContext.Workouts.Select(w => new AllWorkoutsDto()
            {
                Date = w.Date,
                WorkoutName = w.WorkoutName,
                Id = w.Id,
                Intensity = w.Intensity,
                DurationInSeconds = w.DurationInSeconds,
                ImageUrl = w.ImageUrl,
                Exercises = (ICollection<ExerciseDto>)w.Exercises.Select(e => new ExerciseDto()
                {
                    Description = e.Description,
                    DifficultyLevel = e.DifficultyLevel,
                    Id = e.Id,
                    Name = e.Name,
                }),
            });

            return View(workouts);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}