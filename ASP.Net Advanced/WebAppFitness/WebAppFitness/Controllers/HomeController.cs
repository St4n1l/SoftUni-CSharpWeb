using FitnessTracker.Data.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Diagnostics;
using WebAppFitness.Models;

namespace WebAppFitness.Controllers
{
    public class HomeController : UserController
    {
        public HomeController()
        {
        }

        public IActionResult Index()
        {
            if (!User.Identity.IsAuthenticated) 
            {
                return View();
            }

            return RedirectToAction("AllWorkouts", "WorkoutController", null);



        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}