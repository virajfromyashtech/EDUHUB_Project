using System.ComponentModel.DataAnnotations;
 
namespace MVC_EduHub_Project.ViewModels;

public class CourseMaterialViewModel
{
    [Key]
    public int MaterialId { get; set; }
    public string? Course_Title { get; set; }
    public string? Material_Title { get; set; }
    public string? Description { get; set; }
    public string? Url { get; set; }
    public DateTime UploadDate { get; set; }
    public string? ContentType { get; set; }
}
 