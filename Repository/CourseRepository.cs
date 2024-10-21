using MVC_EduHub_Project.Models;
using MVC_EduHub_Project.Services;
 
namespace MVC_EduHub_Project.Repository;
 
public class CourseRepository : ICourseService
{
    private readonly AppDbContext _context;
    public CourseRepository(AppDbContext context)
    {
        _context = context;
    }
    // Retrieves a list of courses associated with a specific user ID.
 
    public List<Course> GetCoursesByUserId(int id)
    {
        var data = _context.Courses.Where(x => x.userId == id).ToList();
        return data;
    }
    // Returns a list of all courses available in the database.
 
    public List<Course> ViewAllCourses()
    {
        var data = _context.Courses.ToList();
        return data;
    }
    // Returns a list of all courses in the database (similar to ViewAllCourses).
    public List<Course> GetAllCourses()
    {
        List<Course> data = _context.Courses.ToList();
 
            return  data;
    }
 
}
 
 