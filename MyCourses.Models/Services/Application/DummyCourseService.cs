using MyCourses.Models.Enums;
using MyCourses.Models.ValueObjects;
using MyCourses.Models.ViewModels;

namespace MyCourses.Models.Services.Application
{
#pragma warning disable
    public class DummyCourseService : ICourseService
    {
        public async Task<List<CourseViewModel>> GetCoursesAsync(string search = null)
        {
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
                    FullPrice = new Money(Enums.Currency.EUR, rand.NextDouble() > 0.5 ? price : price + 1),
                    CurrentPrice = new Money(Enums.Currency.EUR, price)
                };
                courseList.Add(course);
            }
            return courseList;
        }

        public async Task<CourseDetailViewModel> GetCourseAsync(int id)
        {
            var rnd = new Random();
            var price = Convert.ToDecimal(rnd.NextDouble() * 10 + 10);
            var course = new CourseDetailViewModel
            {
                Id = id,
                Title = $"Corso {id}",
                CurrentPrice = new Money(Currency.EUR, price),
                FullPrice = new Money(Currency.EUR, rnd.NextDouble() > 0.5 ? price : price + 1),
                Author = "Nome Cognome",
                Rating = rnd.Next(10, 50) / 10.0,
                ImagePath = "/logo.svg",
                Description = $"Description {id}",
                Lessons = new List<LessonViewModel>()
            };
            for (int i = 0; i < 5; i++)
            {
                var lesson = new LessonViewModel
                {
                    Title = $"Lezione {i}",
                    Duration = TimeSpan.FromSeconds(rnd.Next(40, 90))
                };
                course.Lessons.Add(lesson);
            }
            return course;
        }
    }
}
