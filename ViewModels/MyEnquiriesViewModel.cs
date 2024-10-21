using System.ComponentModel.DataAnnotations;
 
namespace MVC_EduHub_Project.ViewModels;
public class MyEnquiries
{
    [Key]
    public int EnquiryId { get; set; }
    public string? Subject { get; set; }
    public string? Title { get; set; }
    public string? Message { get; set; }
    public DateTime EnquiryDate { get; set; }
    public string? Status { get; set; }
    public string? Response { get; set; }
}
 