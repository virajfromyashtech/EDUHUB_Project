using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MVC_EduHub_Project.Models;
using MVC_EduHub_Project.Services;
 
public class EnquiryController : Controller
{
    private readonly IEnquiryService _enquiryservice;
    private readonly AppDbContext _context;
    public EnquiryController(IEnquiryService enquiryService, AppDbContext context)
    {
        _enquiryservice = enquiryService;
        _context = context;
    }
    // Display Create Enquiry form
    public IActionResult Create()
    {
        var courselist = _context.Courses.Select(c => new SelectListItem
        {
            Text = c.title,
            Value = c.courseId.ToString()
        });
        ViewBag.CourseList = courselist;
        TempData["userid"] = Convert.ToInt32(User.FindFirstValue(ClaimTypes.NameIdentifier));
        return View();
 
    }
    // Handle Create Enquiry form submission
    [HttpPost]
    public IActionResult Create(Enquiry enquiry)
    {
        enquiry.courseId = Convert.ToInt32(enquiry.courseId);
        enquiry.status = "Open";
        enquiry.enquiryDate = DateTime.Now;
        _enquiryservice.Create(enquiry);
        return RedirectToAction("MyEnquiries", "Enquiry", new { id = Convert.ToInt32(User.FindFirstValue(ClaimTypes.NameIdentifier))});
    }
    // Display My Enquiries page
    public IActionResult MyEnquiries()
    {
        int id = Convert.ToInt32(User.FindFirstValue(ClaimTypes.NameIdentifier));
        var data = _enquiryservice.MyEnquiries(id);
        return View(data);
    }
    // Display Enquiries by Course Id
    public IActionResult GetEnquiries(int id){
           
            var data=_enquiryservice.GetEnquiriesByCourseId(id);
            return View(data);
        }
        // Display Edit Enquiry form
        public IActionResult Edit(int id){
            List<SelectListItem> Status=new List<SelectListItem>(){
                new SelectListItem{Text="Open Again",Value="Open"},
                new SelectListItem{Text="In Progress",Value="In Progress"},
                new SelectListItem{Text="Closed",Value="Closed"}
            };
            ViewBag.status=Status;
            var data=_enquiryservice.GetEnquiryByEnquiryId(id);
            return View(data);
        }
        // Handle Edit Enquiry form submission
        [HttpPost]
        public IActionResult Edit(int id,Enquiry enquiry){
            _enquiryservice.Update(id,enquiry);
            return RedirectToAction("GetEnquiries",new{id=enquiry.courseId});
        }
}
 