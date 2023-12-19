using Microsoft.AspNetCore.Mvc;

namespace WebFitnessApp.Controllers
{
    public class CategoryController : Controller
    {
        //        public IActionResult Index()
        //        {
        //              private readonly ICategoryService categoryService;

        //        public CategoryController(ICategoryService categoryService)
        //        {
        //            this.categoryService = categoryService;
        //        }

        //        [HttpGet]
        //        public async Task<IActionResult> All()
        //        {
        //            IEnumerable<AllCategoriesViewModel> viewModel =
        //                await categoryService.AllCategoriesForListAsync();

        //            return View(viewModel);
        //        }

        //        [HttpGet]
        //        public async Task<IActionResult> Details(int id, string information)
        //        {
        //            bool categoryExists = await categoryService.ExistsByIdAsync(id);
        //            if (!categoryExists)
        //            {
        //                return NotFound();
        //            }

        //            CategoryDetailsViewModel viewModel =
        //                await categoryService.GetDetailsByIdAsync(id);
        //            if (viewModel.GetUrlInformation() != information)
        //            {
        //                return NotFound();
        //            }

        //            return View(viewModel);
        //        }
        //    }
        //    }
        //}
    }
}
