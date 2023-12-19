using FitnessTracker.Data.Models;
using FitnessTrackerReal.Data;
using FitnessTrackerReal.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Microsoft.EntityFrameworkCore;

namespace FitnessTrackerReal.Controllers
{

    public class HomeController : BaseController
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _dbContext;

        public HomeController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;        
        }

        public IActionResult Index()
        {
            return View();
        }

        //public async Task<IActionResult> AllWorkoutsAsync()
        //{
        //   //var model = 

        //   // return View(workouts);
        //}

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}