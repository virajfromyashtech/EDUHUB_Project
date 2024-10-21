using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MVC_EduHub_Project.Models;
using Microsoft.Extensions.Hosting;
using IHostingEnvironment = Microsoft.Extensions.Hosting.IHostingEnvironment;
using MVC_EduHub_Project.Services;
namespace MVC_EduHub_Project.Controllers;
public class UserController : Controller
{
  private readonly AppDbContext _context;
  private readonly IUserService _userservice;
  private readonly IWebHostEnvironment _hostingEnvironment;
 
  public UserController(IUserService userservice,AppDbContext context , IWebHostEnvironment hostingEnvironment)
  {
    _userservice = userservice;
    _context = context;
        _hostingEnvironment = hostingEnvironment;
  }
  // Displays the main index view for the user.

  public IActionResult Index()
  {
    return View();
  }
  // Displays the index view for educators.
  public IActionResult EducatorIndex()
  {
    return View();
  }
  // Displays the index view for students.
  public IActionResult StudentIndex()
  {
    
    return View();
  }
 // GET: Displays the view for adding a new user.
  [HttpGet]
  public IActionResult AddUser()
  {
    List<SelectListItem> userroles = new List<SelectListItem>()
       {new SelectListItem { Text = "Eductor", Value = "Eductor" },
        new SelectListItem{ Text="Student",Value="student"},
          };
    ViewBag.role = userroles;
    return View();
  }
  // POST: Handles the submission of the new user form and creates a user.
  [HttpPost]
    public IActionResult AddUser(UserModel model)
  {
    if (ModelState.IsValid)
            {
                string uniqueFileName = null;
 
                // If the Photo property on the incoming model object is not null, then the user
                // has selected an image to upload.
                if (model.Photo != null)
                {
                    // The image must be uploaded to the images folder in wwwroot
                    // To get the path of the wwwroot folder we are using the inject
                    // HostingEnvironment service provided by ASP.NET Core
                    string uploadsFolder = Path.Combine(_hostingEnvironment.WebRootPath, "images/");
                    // To make sure the file name is unique we are appending a new
                    // GUID value and and an underscore to the file name
                    uniqueFileName = Guid.NewGuid().ToString() + "_" + model.Photo.FileName;
                    string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                    // Use CopyTo() method provided by IFormFile interface to
                    // copy the file to wwwroot/images folder
                    model.Photo.CopyTo(new FileStream(filePath, FileMode.Create));
                }
                User newUser = new User
                {
                    UserName = model.UserName,
                    Password = model.Password,
                    role = model.role,
                    email = model.email,
                    mobileNumber = model.mobileNumber,
                    ProfileImage = uniqueFileName
                };
                _userservice.CreateUser(newUser);
                // _context.SaveChanges();
                return RedirectToAction("Index","Home");
 
                }
                return View();
  }
 
 
  // Displays the login view for users.
  public IActionResult Login()
  {
    return View();
  }
  // Displays the login view specifically for students.
  public IActionResult LoginStudent()
  {
    return View();
  }
  // POST: Handles the login process for users.
  [HttpPost]
  public IActionResult Login(LoginViewModel loginuser)
  {
    if (ModelState.IsValid)
    {
      var user = _userservice.Login(loginuser);
      if (user != null)
      {
        var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.UserId.ToString()),
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim(ClaimTypes.Role, user.role),
            };
        var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
        HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));
 
        if (user.role.ToLower() == "eductor")
          return RedirectToAction("SecurePageEducator", "Educator");
        else if (user.role.ToLower() == "student")
          return RedirectToAction("SecurePageStudent","Student");
      }
    }
 
    ModelState.AddModelError("", "Username or Password is not correct");
    return View(loginuser);
  }
  // Displays a secure page for students, only accessible when authorized.
  [Authorize]
  public IActionResult SecurePageStudent()
  {
    ViewBag.Name = HttpContext.User.Identity.Name;
    return View("Index", "Student");
  }
  // Logs out the user and redirects to the home page.
 
  public IActionResult LogOut()
  {
    HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
    return RedirectToAction("Index", "Home");
  }

  [HttpGet]
 
        public IActionResult Details()
        {
            int id = Convert.ToInt32(User.FindFirstValue(ClaimTypes.NameIdentifier));
            var data = _context.Users.FirstOrDefault(s=>s.UserId==id);
 
            return View(data);
        }

        public IActionResult DetailsS()
        {
            int id = Convert.ToInt32(User.FindFirstValue(ClaimTypes.NameIdentifier));
            var data = _context.Users.FirstOrDefault(s=>s.UserId==id);
 
            return View(data);
        }
 
}
 