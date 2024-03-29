using Microsoft.AspNetCore.Mvc;
using MyCourses.Models.Services.Application;
using MyCourses.Models.ViewModels;

namespace MyCourses.Mvc.Controllers
{
    public class CoursesController : Controller
    {
        private ICourseService courseService;

        public CoursesController(ICachedCourseService courseService)
        {
            this.courseService = courseService;
        }

        public async Task<IActionResult> Index(string search = null!)
        {
            List<CourseViewModel> model = await courseService.GetCoursesAsync(search);
            ViewBag.Title = "Catalogo dei corsi";
            return View(model);
        }

        public async Task<IActionResult> Detail(int id)
        {
            CourseDetailViewModel model = await courseService.GetCourseAsync(id);
            ViewBag.Title = model.Title;
            return View(model);
        }
    }
}