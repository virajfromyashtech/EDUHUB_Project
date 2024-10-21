using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using MVC_EduHub_Project.Models;

namespace MVC_EduHub_Project.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }
    // Returns the Index view, typically the home page of the application.

    public IActionResult Index()
    {
        return View();
    }
    // Returns the Register view, used for user registration.
    public IActionResult Register()
    {
        return View();
    }
    // Returns the Login view, used for user authentication.
    public IActionResult Login()
    {
        return View();
    }
    // Returns the Privacy view, typically used to display the application's privacy policy.

    public IActionResult Privacy()
    {
        return View();
    }
    // Returns the Error view, used to display error information when an exception occurs.
    // The ResponseCache attribute is used to prevent caching of error pages.

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
