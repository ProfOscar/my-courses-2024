using System.Data;
using System.Data.SqlClient;
using MyCourses.Models.Enums;
using MyCourses.Models.ValueObjects;
using MyCourses.Models.ViewModels;

namespace MyCourses.Models.Services.Application
{
    public class AdoNetCourseService : ICourseService
    {
        public List<CourseViewModel> GetCourses()
        {
            string connStr = "Server=127.0.0.1,1433; Database=MyCourses.DB; User ID=sa; Password=My1Courses!;";
            using (var conn = new SqlConnection(connStr))
            {
                conn.Open();
                string sql = "SELECT Id, Title, ImagePath, Author, Rating, FullPrice_Currency, FullPrice_Amount, CurrentPrice_Currency, CurrentPrice_Amount FROM Courses";
                using (var cmd = new SqlCommand(sql, conn))
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        DataTable dataTable;
                        do
                        {
                            dataTable = new DataTable();
                            dataTable.Load(reader);
                        } while (!reader.IsClosed);
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
                }
            }
        }

        public CourseDetailViewModel GetCourse(int id)
        {
            throw new NotImplementedException();
        }
    }
}