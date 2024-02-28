using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using MyCourses.Models.ViewModels;

namespace MyCourses.Models.Services.Application
{
    public class MemoryCachedCourseService : ICachedCourseService
    {
        private readonly IConfiguration configuration;
        private readonly IMemoryCache memoryCache;
        private readonly ICourseService courseService;

        public MemoryCachedCourseService(IConfiguration configuration, IMemoryCache memoryCache, ICourseService courseService)
        {
            this.configuration = configuration;
            this.memoryCache = memoryCache;
            this.courseService = courseService;
        }

        public Task<CourseDetailViewModel> GetCourseAsync(int id)
        {
            return memoryCache.GetOrCreateAsync($"Course{id}", cacheEntry =>
            {
                cacheEntry.SetAbsoluteExpiration(getExpirationTimeSpan());
                return courseService.GetCourseAsync(id);
            })!;
        }

        public Task<List<CourseViewModel>> GetCoursesAsync()
        {
            return memoryCache.GetOrCreateAsync("Courses", cacheEntry =>
            {
                cacheEntry.SetAbsoluteExpiration(getExpirationTimeSpan());
                return courseService.GetCoursesAsync();
            })!;
        }

        private TimeSpan getExpirationTimeSpan()
        {
            return TimeSpan.FromSeconds(int.Parse(configuration["CacheExpiration"]!));
        }
    }
}