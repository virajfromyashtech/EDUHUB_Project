using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MVC_EduHub_Project.Models;
using MVC_EduHub_Project.Services;
using MVC_EduHub_Project.ViewModels;
 
namespace MVC_EduHub_Project.Repository;
public class MaterialRepository : IMaterialService
{
    private readonly AppDbContext _context;
    public MaterialRepository(AppDbContext context)
    {
        _context = context;
    }
    public void AddMaterial(Material material)
    {
        _context.Materials.Add(material);
        _context.SaveChanges();
    }
 
    public void DeleteMaterial(int id)
    {
        var data = _context.Materials.FirstOrDefault(x => x.materialId == id);
        _context.Materials.Remove(data);
        _context.SaveChanges();
    }
 
    public void UpdateMaterial(int id, Material material)
    {
        var data = _context.Materials.FirstOrDefault(x => x.materialId == id);
        data.title = material.title;
        data.description = material.description;
        data.uploadDate = material.uploadDate;
        data.URL = material.URL;
        _context.SaveChanges();
    }
 
    public List<CourseMaterialViewModel> ViewAllMaterial(int id)
    {
        var data =  _context.CourseMaterials.FromSqlInterpolated($"SP_MaterialsByCourses {id}").ToList();
        return data;
    }
    public Material GetMaterialByMaterialId(int id)
    {
        var data = _context.Materials.FirstOrDefault(x => x.materialId == id);
        return data;
    }

    public Material CreateMaterial(Material newmaterial)
    {
        _context.Materials.Add(newmaterial);
        _context.SaveChanges();
        return newmaterial;
    }
}
 
 