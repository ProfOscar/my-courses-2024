using System.Data;
using MyCourses.Models.Enums;
using MyCourses.Models.Services.Infrastructure;
using MyCourses.Models.ValueObjects;
using MyCourses.Models.ViewModels;

namespace MyCourses.Models.Services.Application
{
    public class AdoNetCourseService : ICourseService
    {
        private readonly IDatabaseAccessor db;
        public AdoNetCourseService(IDatabaseAccessor db)
        {
            this.db = db;
        }

        public List<CourseViewModel> GetCourses()
        {
            string sql = "SELECT Id, Title, ImagePath, Author, Rating, FullPrice_Currency, FullPrice_Amount, CurrentPrice_Currency, CurrentPrice_Amount FROM Courses";
            DataSet dataSet = db.Query(sql);
            DataTable dataTable = dataSet.Tables[0];
            var courseList = new List<CourseViewModel>();
            foreach (DataRow courseRow in dataTable.Rows)
            {
                CourseViewModel course = new CourseViewModel
                {
                    Title = Convert.ToString(courseRow["Title"])!,
                    ImagePath = Convert.ToString(courseRow["ImagePath"])!,
                    Author = Convert.ToString(courseRow["Author"])!,
                    Rating = Convert.ToDouble(courseRow["Rating"]),
                    FullPrice = new Money(
                        Enum.Parse<Currency>(Convert.ToString(courseRow["FullPrice_Currency"])!),
                        Convert.ToDecimal(courseRow["FullPrice_Amount"])
                    ),
                    CurrentPrice = new Money(
                        Enum.Parse<Currency>(Convert.ToString(courseRow["CurrentPrice_Currency"])!),
                        Convert.ToDecimal(courseRow["CurrentPrice_Amount"])
                    ),
                    Id = Convert.ToInt32(courseRow["Id"])
                };
                courseList.Add(course);
            }
            return courseList;

        }

        public CourseDetailViewModel GetCourse(int id)
        {
            throw new NotImplementedException();
        }
    }
}