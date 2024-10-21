namespace MVC_EduHub_Project.Models;

public class Enquiry
{
    public int enquiryId  { get; set; }
    public int userId  { get; set; }
    public int courseId {get; set;}
    public string subject { get; set; }
    public string message {get; set;}
    public  DateTime enquiryDate { get; set; }
    public string status  { get; set; }
    public  string response { get; set; }
}
