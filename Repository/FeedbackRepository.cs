using Microsoft.EntityFrameworkCore;
using MVC_EduHub_Project.Models;
using MVC_EduHub_Project.Services;
using MVC_EduHub_Project.ViewModels;

namespace MVC_EduHub_Project.Repository;
public class FeedbackRepository:IFeedbackService
{
    private readonly AppDbContext _context;
    public FeedbackRepository(AppDbContext context)
    {
        _context = context;
    }
    public List<Feedback> ViewAllFeedbacks()
    {
        var data = _context.Feedbacks.ToList();
        return data;
    }
    public void Create(Feedback feedback)
    {
        _context.Feedbacks.Add(feedback);
        _context.SaveChanges();
    }
    public IEnumerable<FeedbackByUserName> GetFeedbackByCourseId(int courseId)
    {
        return _context.FeedbackByUserNames.FromSqlInterpolated($"FeedbackByUserName {courseId}").ToList();
    }

    public Feedback CreateFeedback(Feedback newFeedback)
    {
       
        _context.Feedbacks.Add(newFeedback);
        _context.SaveChanges();
        return newFeedback;
    }
 

}
 