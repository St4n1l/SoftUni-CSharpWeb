using Microsoft.AspNetCore.Mvc;

namespace WebAppFitness.Controllers
{
    public class StatController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
