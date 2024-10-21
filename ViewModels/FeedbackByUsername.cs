using System.ComponentModel.DataAnnotations;
using MVC_EduHub_Project.Models;
using Microsoft.EntityFrameworkCore;
 
namespace MVC_EduHub_Project.ViewModels;
 
[Keyless]
public class FeedbackByUserName
{
   
 
    public string Username { get; set; }
    public string UserFeedback { get; set; }
 
    public DateTime Date { get; set; }
 
   
 
}
 
 