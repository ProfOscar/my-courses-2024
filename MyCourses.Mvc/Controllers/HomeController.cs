using Microsoft.AspNetCore.Mvc;

namespace MyCourses.Mvc.Controllers
{
    public class HomeController : Controller
    {
        [ResponseCache(Duration = 60, Location = ResponseCacheLocation.Client)]
        public IActionResult Index()
        {
            ViewBag.Title = "MyCourses - Homepage";
            return View();
        }
    }
}