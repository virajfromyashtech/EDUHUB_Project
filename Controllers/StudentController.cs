using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MVC_EduHub_Project.Models;
 
namespace MVC_EduHub_Project.Controllers;
public class StudentController : Controller
{
    private readonly AppDbContext _context;
    public StudentController(AppDbContext context)
    {
       _context = context;
    }
    [Authorize]
    public IActionResult SecurePageStudent()
    {
      // This action is secured by the Authorize attribute, meaning only authenticated users can access it.
        // Upon accessing this action, the user will be redirected to the Index action.
      return RedirectToAction("Index");
    }
    public IActionResult Index()
    {
      // This action sets the ViewBag.Name property to the current user's identity name.
        // It then returns the Index view, which can use the ViewBag to display the user's name.
        ViewBag.Name = User.Identity.Name;
        return View();
    }
   
}
 