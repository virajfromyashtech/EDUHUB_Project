using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MVC_EduHub_Project;
using MVC_EduHub_Project.Models;
using MVC_EduHub_Project.Services;
 
public class EducatorController : Controller
{
    private readonly ICourseService _courseservice;
    private readonly AppDbContext _context;
    public EducatorController(ICourseService courseService, AppDbContext context)
    {
        _courseservice = courseService;
        _context = context;
    }
    // Executes when the Index page is accessed; sets the username in ViewBag and returns the Index view.
 
    public IActionResult Index()
    {
        ViewBag.Username = User.Identity.Name;
        return View();
    }
    // Retrieves and displays all courses; sets the user's role in ViewBag and returns the View with course data.
    public IActionResult ViewAllCourses()
    {
        ViewBag.Role = User.FindFirstValue(ClaimTypes.Role);
        var data = _courseservice.ViewAllCourses();
        return View(data);
    }
    // Redirects authenticated educators to the Index page; requires authorization.
    [Authorize]
    public IActionResult SecurePageEducator()
    {
        return RedirectToAction("Index");
    }
    // Displays the Create Course view.
    public IActionResult Createcourse()
    {
        List<SelectListItem> levels = new List<SelectListItem>()
       {new SelectListItem { Text = "Beginner", Value = "beginner" },
        new SelectListItem{ Text="Advanced",Value="advanced"},
          };
          ViewBag.level = levels;
          
        return View();
    }
    // Handles the form submission for creating a new course; if valid, saves the course and redirects to ViewAllCourses.
    [HttpPost]
    public IActionResult Createcourse(Course course)
    {
        if (ModelState.IsValid)
        {
            _context.Courses.Add(course);
            _context.SaveChanges();
            return RedirectToAction("Viewallcourses");
        }
        return View();
    }
    // Displays the Edit Course view for a specific course by ID; returns NotFound if the course does not exist.
    [HttpGet]
    public IActionResult Editcourse(int? id)
    {
        if (id == null)
            return View();
        else
        {
            var data = _context.Courses.FirstOrDefault(x => x.userId == id);
            if (data == null)
                return NotFound();
            return View(data);
        }
    }
    // Handles the form submission for editing a course; updates the course details and redirects to ViewAllCourses.
    [HttpPost]
    public IActionResult Editcourse(int id, Course newcourse)
    {
        List<SelectListItem> levels = new List<SelectListItem>()
       {new SelectListItem { Text = "Beginner", Value = "beginner" },
        new SelectListItem{ Text="Advanced",Value="advanced"},
          };
        var data = _context.Courses.FirstOrDefault(y => y.courseId == id);
        if (data == null) return NotFound();
        data.title = newcourse.title;
        data.description = newcourse.description;
        data.courseStartDate = newcourse.courseStartDate;
        data.CourseEndDate = newcourse.CourseEndDate;
        data.category = newcourse.category;
        ViewBag.level = levels;
        data.level = newcourse.level;
        _context.SaveChanges();
        return RedirectToAction(nameof(ViewAllCourses));
    }
    // Displays the Delete Course view for a specific course by ID; returns NotFound if the course does not exist.
    [HttpGet]
    public IActionResult Deletecourse(int? id)
    {
        if (id == null)
            return View();
        else
        {
            var data = _context.Courses.FirstOrDefault(x => x.courseId == id);
            if (data == null)
                return NotFound();
            return View(data);
        }
    }
    // Handles the form submission for deleting a course; removes the course and redirects to ViewAllCourses.
    [HttpPost]
    public IActionResult Deletecourse(int id, Course newstudent)
    {
        var data = _context.Courses.FirstOrDefault(y => y.courseId == id);
        if (data == null) return NotFound();
        _context.Courses.Remove(data);
        _context.SaveChanges();
        return RedirectToAction(nameof(ViewAllCourses));
    }
    // Retrieves and displays courses created by the logged-in user; returns NotFound if no courses are found.
    public IActionResult GetCourseByUserId()
    {
 
        var data = _courseservice.GetCoursesByUserId(Convert.ToInt32(User.FindFirstValue(ClaimTypes.NameIdentifier)));
        if (data == null) return NotFound();
        return View(data);
    }
    // Retrieves and displays all courses from the database
    public IActionResult AllCourse()
    {
        var data = _context.Courses.ToList();
        return View(data);

    }
}
 