using MVC_EduHub_Project.Models;
using MVC_EduHub_Project.ViewModels;
 
namespace MVC_EduHub_Project.Services;
public interface IFeedbackService
{
    List<Feedback> ViewAllFeedbacks();
    void Create(Feedback feedback);
    IEnumerable<FeedbackByUserName> GetFeedbackByCourseId(int courseId);
    Feedback CreateFeedback(Feedback newfeedback);
 
}