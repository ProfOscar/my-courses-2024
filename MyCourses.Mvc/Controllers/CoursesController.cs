using Microsoft.AspNetCore.Mvc;
using MyCourses.Models.Services.Application;
using MyCourses.Models.ViewModels;

namespace MyCourses.Mvc.Controllers
{
    public class CoursesController : Controller
    {
        public IActionResult Index()
        {
            CourseService courseService = new CourseService();
            List<CourseViewModel> model = courseService.GetCourses();
            ViewBag.Title = "Catalogo dei corsi";
            return View(model);
        }

        public IActionResult Detail(int id)
        {
            CourseService courseService = new CourseService();
            CourseDetailViewModel model = courseService.GetCourse(id);
            ViewBag.Title = model.Title;
            return View(model);
        }
    }
}