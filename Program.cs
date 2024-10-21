using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using MVC_EduHub_Project;
using MVC_EduHub_Project.Models;
using MVC_EduHub_Project.Repository;
using MVC_EduHub_Project.Services;
 

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("MyConstr") ?? throw new InvalidOperationException("Connection string 'AppDBContextConnection' not found.");
 builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(connectionString));

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie();
builder.Services.AddScoped<IUserService, UserRepository>();
builder.Services.AddScoped<ICourseService, CourseRepository>();
builder.Services.AddScoped<IMaterialService, MaterialRepository>();
builder.Services.AddScoped<IEnrollmentService, EnrollmentRepository>();
builder.Services.AddScoped<IFeedbackService, FeedbackRepository>();
builder.Services.AddScoped<IEnquiryService, EnquiryRespository>();
 

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
