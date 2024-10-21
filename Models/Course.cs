using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
namespace MVC_EduHub_Project.Models;

public class Course
{
    public  int courseId { get; set; }
    public string title { get; set; }
    public string description {get; set;}
    public DateTime courseStartDate  { get; set; }

    public DateTime CourseEndDate  { get; set; }
    public int userId  { get; set; }
    public string category  { get; set; }
    public string level {get; set;}

}