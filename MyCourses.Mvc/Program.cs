using MyCourses.Models.Services.Application;
using MyCourses.Models.Services.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// builder.Services.AddTransient<ICourseService, DummyCourseService>();
builder.Services.AddTransient<ICourseService, AdoNetCourseService>();

builder.Services.AddTransient<IDatabaseAccessor, SqlServerDabaseAccessor>();

builder.Services.AddControllersWithViews();


var app = builder.Build();

app.UseStaticFiles();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}"
);

app.Run();
