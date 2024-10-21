using MVC_EduHub_Project.Models;
using MVC_EduHub_Project.ViewModels;
 
namespace MVC_EduHub_Project.Services;
public interface IMaterialService
{
     List<CourseMaterialViewModel> ViewAllMaterial(int id);
     void AddMaterial(Material material);
     void UpdateMaterial(int id, Material material);
     void DeleteMaterial(int id);
     Material GetMaterialByMaterialId(int id);
 
}
 