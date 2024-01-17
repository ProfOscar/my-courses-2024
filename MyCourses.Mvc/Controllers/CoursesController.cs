using Microsoft.AspNetCore.Mvc;
using MyCourses.Models.Entities;
using MyCourses.Models.Services.Application;
using MyCourses.Models.ViewModels;

namespace MyCourses.Mvc.Controllers
{
    public class CoursesController : Controller
    {
        public IActionResult Index()
        {
            CourseService courseService = new CourseService();
            List<CourseViewModel> courses = courseService.GetCourses();
            return View(courses);
        }

        public IActionResult Detail(string id)
        {
            Course c = new Course(int.Parse(id), "Test Course " + id, "Description for course " + id, "");
            // return Content($"Sono Detail di Courses: {c}");
            return View();
        }
    }
}