using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebFitnessApp.Data;
using WebFitnessApp.Data.ViewModels;

namespace WebFitnessApp.Controllers
{
    public class WorkoutController : Controller
    {
        private readonly ApplicationDbContext dbContext;

        public WorkoutController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<IActionResult> All()
        {
            return View(new AllWorkoutsQueryModel());
        }

        [Authorize]
        public async Task<IActionResult> Mine()
        {
            return View(new AllWorkoutsQueryModel());
        }

        public async Task<IActionResult> Details(int id)
        {
            return View(new WorkoutDetailsViewModel());
        }

        [Authorize]
        public async Task<IActionResult> Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(WorkoutFormModel model)
        {
            return RedirectToAction(nameof(Details), new { id = "1" });
        }

        public async Task<IActionResult> Edit(int id)
        {
            return View(new WorkoutFormModel());
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, WorkoutFormModel workout)
        {
            return RedirectToAction(nameof(Details), new { id = 1, });
        }

        public async Task<IActionResult> Delete(int id)
        {
            return View(new WorkoutFormModel());
        }

        [HttpPost]
        public async Task<IActionResult> Delete(WorkoutDetailsViewModel workout)
        {
            return View(nameof(All));
        }

        [HttpPost]
        public async Task<IActionResult> AddToMyCollection(int id)
        {
            return RedirectToAction(nameof(Mine));
        }

        [HttpPost]
        public async Task<IActionResult> RemoveFromMyCollection(int id)
        {
            return RedirectToAction(nameof(Mine));
        }
    }
}
