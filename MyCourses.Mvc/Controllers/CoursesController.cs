using Microsoft.AspNetCore.Mvc;
using MyCourses.Models.Entities;

namespace MyCourses.Mvc.Controllers
{
    public class CoursesController : Controller
    {
        public IActionResult Index()
        {
            // return Content("Sono Index di Courses");
            return View();
        }

        public IActionResult Detail(string id)
        {
            Course c = new Course(int.Parse(id), "Test Course " + id, "Description for course " + id, "");
            // return Content($"Sono Detail di Courses: {c}");
            return View();
        }
    }
}