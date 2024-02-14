using System.Data;

namespace MyCourses.Models.ViewModels
{
    public class LessonViewModel
    {
        private int Id { get; set; }
        public string? Title { get; set; }
        public TimeSpan Duration { get; set; }

        public static LessonViewModel FromDataRow(DataRow dataRow)
        {
            LessonViewModel lesson = new()
            {
                Id = Convert.ToInt32(dataRow["Id"]),
                Title = Convert.ToString(dataRow["Title"]),
                Duration = TimeSpan.Parse(Convert.ToString(dataRow["Duration"])!)
            };
            return lesson;
        }
    }
}