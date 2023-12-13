using MyCourses.Models.Entities;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.UseStaticFiles();

Course c = new(1, "Test Course", "Simple test for project cross reference", "");
app.MapGet("/", () => c.ToString());

app.Run();
