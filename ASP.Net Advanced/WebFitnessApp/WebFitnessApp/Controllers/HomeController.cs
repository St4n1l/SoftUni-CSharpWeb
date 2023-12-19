using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebFitnessApp.Contracts;
using WebFitnessApp.Data;
using WebFitnessApp.Data.ViewModels;
using WebFitnessApp.Models;

namespace WebFitnessApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly IWorkoutService _workouts;

        public HomeController(IWorkoutService workouts)
        {
            _workouts = workouts;
        }

        public async Task<IActionResult> Index()
        {
            var workouts = await _workouts.LastThreeWorkouts();

            return View(workouts);

        }

        public IActionResult BecomeInstructor()
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("AllWorkouts", "WorkoutController", null);
            }

            return RedirectToAction("BecomeInstructor", "UserController", null);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}