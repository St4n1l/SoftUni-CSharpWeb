using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;

namespace Library.Controllers
{
    public class BaseController : Controller
    {
        public string GetUserId()
        {
            var id = string.Empty;

            if (User != null)
            {
                id = User.FindFirstValue(ClaimTypes.NameIdentifier);
            }

            return id;
        }
    }
}
