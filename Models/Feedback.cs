using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
namespace MVC_EduHub_Project.Models;

public class Feedback
{
    public int FeedbackId { get; set; }
    public int userId {get; set;}
    public int courseId {get; set;}
    public  string UserFeedback { get; set; }
    public DateTime date  { get; set; }


}