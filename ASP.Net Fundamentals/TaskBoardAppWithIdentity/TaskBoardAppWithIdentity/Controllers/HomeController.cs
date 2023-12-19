using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TaskBoardAppWithIdentity.Models;

namespace TaskBoardAppWithIdentity.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

    }
}