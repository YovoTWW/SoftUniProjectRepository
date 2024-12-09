using Microsoft.AspNetCore.Mvc;

namespace EuropeBJJ.Controllers
{
    public class ProfileController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
