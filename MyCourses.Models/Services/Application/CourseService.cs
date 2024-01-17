using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyCourses.Models.Entities;

namespace MyCourses.Models.Services.Application
{
    public class CourseService
    {
        public List<Course> GetCourses(){
            var courseList = new List<Course>();
            var rand = new Random();
            for (int i = 0; i <= 20; i++)
            {
                var price = Convert.ToDecimal(rand.NextDouble() * 10 + 10);
                var course = new Course
                (
                    i,
                    $"Corso {i}",
                    $"Description {i}",
                    "/logo.svg"
                );
                courseList.Add(course);
            }
            return courseList;
        }
    }
}