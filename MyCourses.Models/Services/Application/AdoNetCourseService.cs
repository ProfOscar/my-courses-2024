using System.Data;
using Microsoft.Extensions.Logging;
using MyCourses.Models.Services.Infrastructure;
using MyCourses.Models.ViewModels;

namespace MyCourses.Models.Services.Application
{
    public class AdoNetCourseService : ICourseService
    {
        private readonly ILogger<AdoNetCourseService> logger;
        private readonly IDatabaseAccessor db;
        public AdoNetCourseService(ILogger<AdoNetCourseService> logger, IDatabaseAccessor db)
        {
            this.logger = logger;
            this.db = db;
        }

        public async Task<List<CourseViewModel>> GetCoursesAsync(string search)
        {
            logger.LogInformation("Courses list requested");
            FormattableString sql = $"SELECT Id, Title, ImagePath, Author, Rating, FullPrice_Currency, FullPrice_Amount, CurrentPrice_Currency, CurrentPrice_Amount FROM Courses WHERE title LIKE {"%" + search + "%"}";
            DataSet dataSet = await db.QueryAsync(sql);
            DataTable dataTable = dataSet.Tables[0];
            var courseList = new List<CourseViewModel>();
            foreach (DataRow courseRow in dataTable.Rows)
            {
                CourseViewModel course = CourseViewModel.FromDataRow(courseRow);
                courseList.Add(course);
            }
            return courseList;
        }

        public async Task<CourseDetailViewModel> GetCourseAsync(int id)
        {
            logger.LogInformation("Course {id} requested", id);
            FormattableString sql = $@"SELECT Id, Title, Description, ImagePath, Author, Rating, FullPrice_Amount, FullPrice_Currency, CurrentPrice_Amount, CurrentPrice_Currency FROM Courses WHERE Id={id};
                SELECT Id, Title, Description, Duration FROM Lessons WHERE CourseId={id}";
            DataSet dataSet = await db.QueryAsync(sql);

            // course
            var courseTable = dataSet.Tables[0];
            if (courseTable.Rows.Count != 1)
                throw new InvalidOperationException($"La query dovrebbe restituire esattamente una riga per il corso {id}");
            var courseRow = courseTable.Rows[0];
            var courseDetailViewModel = CourseDetailViewModel.FromDataRow(courseRow);

            // lessons
            var lessonsTable = dataSet.Tables[1];
            foreach (DataRow lessonRow in lessonsTable.Rows)
            {
                LessonViewModel lesson = LessonViewModel.FromDataRow(lessonRow);
                courseDetailViewModel.Lessons!.Add(lesson);
            }

            return courseDetailViewModel;
        }
    }
}