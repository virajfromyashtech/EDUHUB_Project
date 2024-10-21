using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
 
namespace MVC_EduHub_Project.ViewModels;
public class EnrollmentViewModel
{
    [Key]
    public int EnrollmentId { get; set; }
    public string? Username { get; set; }
    public string? Title { get; set; }
    public DateTime EnrollmentDate { get; set; }
    public string? Status { get; set; }
}
 