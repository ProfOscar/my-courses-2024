using MyCourses.Models.ViewModels;

namespace MyCourses.Models.Services.Application
{
    public class CourseService
    {
        public List<CourseViewModel> GetCourses(){
            var courseList = new List<CourseViewModel>();
            var rand = new Random();
            for (int i = 0; i <= 20; i++)
            {
                var price = Convert.ToDecimal(rand.NextDouble() * 10 + 10);
                var course = new CourseViewModel
                {
                    Id = i,
                    Title = $"Corso {i}",
                    ImagePath = "/logo.svg",
                    Author = "Nome Cognome",
                    Rating = rand.Next(10, 50) / 10.0,
                    FullPrice = rand.NextDouble() > 0.5 ? price : price + 1,
                    CurrentPrice = price
                };
                courseList.Add(course);
            }
            return courseList;
        }
    }
}