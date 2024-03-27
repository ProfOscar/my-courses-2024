using MyCourses.Models.ViewModels;

namespace MyCourses.Models.Services.Application
{
    public interface ICourseService
    {
        Task<List<CourseViewModel>> GetCoursesAsync(string search);
        Task<CourseDetailViewModel> GetCourseAsync(int id);
    }
}