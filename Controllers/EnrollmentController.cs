using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MVC_EduHub_Project.Models;
using MVC_EduHub_Project.Services;
 
public class EnrollmentController : Controller
{
    private readonly IEnrollmentService _enrollmentservice;
    private readonly AppDbContext _context;
    public EnrollmentController(IEnrollmentService enrollmentService, AppDbContext context)
    {
        _enrollmentservice = enrollmentService;
        _context = context;
    }
    // Displays a list of enrolled students
    public IActionResult EnrolledStudents()
    {
        int id = Convert.ToInt32(User.FindFirstValue(ClaimTypes.NameIdentifier));
        var data = _enrollmentservice.EnrolledStudents(id);
        return View(data);
    }
    // Displays a list of pending students
    public IActionResult PendingStudents()
    {
        int id = Convert.ToInt32(User.FindFirstValue(ClaimTypes.NameIdentifier));
        var data = _enrollmentservice.PendingStudents(id);
        return View(data);
    }
    // Updates a student's enrollment status to accepted
    [HttpPost]
    public IActionResult UpdateToAccept(int id)
    {
        _enrollmentservice.UpdateToAccept(id);
        return RedirectToAction("EnrolledStudents");
    }
    // Updates a student's enrollment status to rejected
    [HttpPost]
    public IActionResult UpdateToReject(int id)
    {
        _enrollmentservice.UpdateToReject(id);
        return RedirectToAction("PendingStudents");
    }
    // Displays a list of a student's enrollments
    [HttpGet]
    public IActionResult StudentEnrollments()
    {
        int id = Convert.ToInt32(User.FindFirstValue(ClaimTypes.NameIdentifier));
        var data = _enrollmentservice.StudentEnrollments(id);
        return View(data);
    }
    // Creates a new enrollment for a student
    public IActionResult Create(int id)
    {
        var courselist = _context.Courses.Select(c => new SelectListItem
        {
            Text = c.title,
            Value = c.courseId.ToString()
        });
        ViewBag.courseId=id;
        ViewBag.CourseList = courselist;
        TempData["userid"] = Convert.ToInt32(User.FindFirstValue(ClaimTypes.NameIdentifier));
        TempData.Keep();
        return View();
    }
    // Creates a new enrollment for a student (HTTP POST)
 
    [HttpPost]
    public IActionResult Create(Enrollment enrollment)
    {
        enrollment.enrollmentDate = DateTime.Now;
        enrollment.status = "Pending";
        _enrollmentservice.Create(enrollment);
        return RedirectToAction("StudentEnrollments", new { id = enrollment.userId });
    }
 
}
 