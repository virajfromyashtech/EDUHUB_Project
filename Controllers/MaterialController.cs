using System.Net.Mime;
using System.Security.Claims;
using System.Security.Principal;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MVC_EduHub_Project.Models;
using MVC_EduHub_Project.Services;
 
public class MaterialController : Controller
{
    private readonly IMaterialService _materialservice;
    public MaterialController(IMaterialService materialService)
    {
       _materialservice = materialService;
    }
    // GET: Displays a list of materials for a specific course identified by id
    public IActionResult Index(int id)
    {
        var data = _materialservice.ViewAllMaterial(id);
        TempData["CourseId"] = id;
        TempData.Keep("CourseId");
        if(data == null) return NotFound();
        return View(data);
    }
    public IActionResult Index1(int id)
    {
        var data = _materialservice.ViewAllMaterial(id);
        TempData["CourseId"] = id;
        TempData.Keep("CourseId");
        if(data == null) return NotFound();
        return View(data);
    }
    // GET: Returns the view for creating a new material for a specific course identified by id
    [HttpGet]
    public IActionResult Create(int id)
    {
        List<SelectListItem> content = new List<SelectListItem>()
       {new SelectListItem { Text = "lecture", Value = "lecture" },
        new SelectListItem{ Text="slides",Value="slides"},
        new SelectListItem{ Text="video",Value="video"},
        new SelectListItem{ Text="quiz",Value="quiz"},
        new SelectListItem{ Text="Other",Value="other"},
          };
           
          ViewBag.contentType= content;
        TempData["CourseId"] = id;
        TempData.Keep("CourseId");
        return View();
        // POST: Handles the submission of a new material and redirects to the Index actioniew();
    }
    [HttpPost]
    public IActionResult Create(int id,Material material)
    {
        _materialservice.AddMaterial(material);
        return RedirectToAction("Index",new{id=material.courseId});
    }
    // GET: Returns the view for updating a specific material identified by id
    [HttpGet]
    public IActionResult Update(int id)
    {
        if(id == null) return View();
        else{
            var data = _materialservice.GetMaterialByMaterialId(id);
            return View(data);
        }
    }
    // POST: Handles the submission of an updated material and redirects to the Index action
    [HttpPost]
    public IActionResult Update(int id, Material material)
    {
        var data=_materialservice.GetMaterialByMaterialId(id);
        _materialservice.UpdateMaterial(id,material);
        return RedirectToAction("Index",new{id=data.courseId});
    }
    // GET: Returns the view for confirming the deletion of a specific material identified by id
    [HttpGet]
    public IActionResult Delete(int id)
    {
        var data = _materialservice.GetMaterialByMaterialId(id);
        return View(data);
    }
    // POST: Handles the deletion of a specific material and redirects to the Index action
    [HttpPost]
    public IActionResult Delete(int id, Material material)
    {
        var data=_materialservice.GetMaterialByMaterialId(id);
        _materialservice.DeleteMaterial(id);
        return RedirectToAction("Index",new{id=data.courseId});
    }
}
 