using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.Blazor;
using MVC_EduHub_Project.Models;
using MVC_EduHub_Project.ViewModels;
 
namespace MVC_EduHub_Project.Services;
public interface IEnquiryService
{
    List<MyEnquiries> MyEnquiries(int id);
    void Create(Enquiry enquiry);
    List<Enquiry> GetEnquiriesByCourseId(int id);
    Enquiry GetEnquiryByEnquiryId(int id);
    void Update(int id,Enquiry enquiry);
}
 