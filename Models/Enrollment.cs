namespace MVC_EduHub_Project.Models;

public class Enrollment
{
    public int enrollmentId { get; set; }
    public int userId { get; set; }
    public int courseId  { get; set; }
    public DateTime enrollmentDate  { get; set; }
    public string status  { get; set; }



}