using MyCourses.Models.Services.Application;

var builder = WebApplication.CreateBuilder(args);

// builder.Services.AddTransient<ICourseService, DummyCourseService>();
builder.Services.AddTransient<ICourseService, AdoNetCourseService>();

builder.Services.AddControllersWithViews();


var app = builder.Build();

app.UseStaticFiles();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}"
);

app.Run();
