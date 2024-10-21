using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using MVC_EduHub_Project.Models;
using MVC_EduHub_Project.Services;
 
namespace MVC_EduHub.Controllers;
public class FeedbackController : Controller
{
    private readonly IFeedbackService _feedbackservice;
    public FeedbackController(IFeedbackService feedbackService)
    {
       _feedbackservice = feedbackService;
    }
    // Displays all feedbacks
    public IActionResult Index()
    {
        var data = _feedbackservice.ViewAllFeedbacks();
        return View(data);
    }
    // Creates a new feedback for a course
    public IActionResult Create(int id)
    {
        ViewBag.courseId=id;
 
        TempData["userid"] = Convert.ToInt32(User.FindFirstValue(ClaimTypes.NameIdentifier));
        TempData.Keep();
        return View();
    }
    // Creates a new feedback
 
    [HttpPost]
    public IActionResult Create(Feedback feedback)
    {
        feedback.date = DateTime.Now;
        _feedbackservice.Create(feedback);
        return RedirectToAction("Index","Student");
    }
    // Displays feedbacks for a course
    [HttpGet]
    public IActionResult MyFeedback(int id)
    {
 
            // var id = Convert.ToInt32(HttpContext.Session.GetString("CourseId"));
            var data = _feedbackservice.GetFeedbackByCourseId(id);
            return View(data);
    }
    // Adds a new feedback for a course

    [HttpGet]
    public IActionResult AddFeedback(int id)
    {
        var id2 = Convert.ToInt32(HttpContext.Session.GetString("UserId"));
        ViewBag.UserId = id2;
        ViewBag.CourseId = id;
       
        ViewBag.EnrollmentDate = DateTime.Now;
        return View();
    }
    // Creates a new feedback
 
 
    [HttpPost]
    public IActionResult AddFeedback(Feedback newfeedback)
    {
 
        _feedbackservice.CreateFeedback(newfeedback);
        return RedirectToAction("Index","Home");
    }
 
}
 