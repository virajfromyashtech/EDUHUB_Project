using Microsoft.EntityFrameworkCore;
using MVC_EduHub_Project.Models;
using MVC_EduHub_Project.ViewModels;
 
namespace MVC_EduHub_Project.Models;
public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
    public DbSet<User> Users { get; set; }
    public DbSet<LoginViewModel> LoginViewModel { get; set; }
    public DbSet<Course> Courses { get; set; }
    public DbSet<Material> Materials { get; set; }
    public DbSet<Enrollment> Enrollments { get; set; }
    public DbSet<EnrollmentViewModel> EnrolledStudents { get; set; }
    public DbSet<CourseMaterialViewModel> CourseMaterials { get; set; }
    public DbSet<Enquiry> Enquiries { get; set; }
    public DbSet<Feedback> Feedbacks { get; set; }
    public DbSet<EnrollmentByStudent> EnrollmentByStudents { get; set; }
    public DbSet<MyEnquiries> StudentEnquiries { get; set; }

    public DbSet<FeedbackByUserName> FeedbackByUserNames{get; set;}
 
 
 
}
 