using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebFitnessApp.Contracts;
using WebFitnessApp.Data;
using WebFitnessApp.Data.ViewModels;
using WebFitnessApp.Infrastructure;
using WebFitnessApp.Services.Instructor;
using static WebFitnessApp.NotificationMessagesConstants;

namespace WebFitnessApp.Controllers
{
    [Authorize]
    public class InstructorController : Controller
    {
        private readonly IInstructorService _instructors;
        private readonly ApplicationDbContext _db;
        public InstructorController(IInstructorService instructors, ApplicationDbContext db)
        {
            _instructors = instructors;
            _db = db;
        }

        [HttpGet]
        public async Task<IActionResult> Become()
        {
            string? userId = User.GetId();
            bool isinstructor = await _instructors.ExistsById(userId!);

            if (isinstructor)
            {
                TempData[ErrorMessage] = "You are already an instructor!";

                return RedirectToAction("Index", "Home");
            }

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Become(BecomeInstructorFormModel model)
        {
            string? userId = User.GetId();

            bool isinstructor = await _instructors.ExistsById(userId);
            if (isinstructor)
            {
                return BadRequest();
            }

            bool isPhoneNumberTaken =
                await _instructors.InstructorWithPhoneNumberExists(model.PhoneNumber);
            if (isPhoneNumberTaken)
            {
                ModelState.AddModelError(nameof(model.PhoneNumber), "Phone number is always taken.");
            }

            if (_db.Workouts.Any())
            {
                if (await _instructors.HasWorkouts(userId))
                {
                    ModelState.AddModelError("Error", "You shouldn't have any workouts saved to become an instructor!");
                }
            }

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            try
            {
                await _instructors.Create(userId, model);
            }
            catch (Exception)
            {
                ModelState.AddModelError("Error", "Unexpected error occurred.");
            }

            return RedirectToAction(nameof(WorkoutController.All), "Workout");
        }
    }
}
