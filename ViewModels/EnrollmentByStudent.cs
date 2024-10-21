using System.ComponentModel.DataAnnotations;
 
namespace MVC_EduHub_Project.ViewModels;
public class EnrollmentByStudent
{
    [Key]
    public int EnrollmentId { get; set; }
    public string? Title { get; set; }
    public string? Description { get; set; }
    public string? Category { get; set; }
    public string? Level { get; set; }
    public DateTime EnrollmentDate { get; set; }
}
 