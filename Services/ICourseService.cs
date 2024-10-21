using MVC_EduHub_Project.Models;

namespace MVC_EduHub_Project;

public  interface ICourseService
{
    List<Course> ViewAllCourses();

    List<Course> GetCoursesByUserId(int id);
}
