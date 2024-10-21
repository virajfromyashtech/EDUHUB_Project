using Microsoft.EntityFrameworkCore;
using MVC_EduHub_Project.Models;
using MVC_EduHub_Project.Services;
using MVC_EduHub_Project.ViewModels;
 
namespace MVC_EduHub_Project.Repository;
// This class implements the IEnquiryService interface and provides methods to manage enquiries.
public class EnquiryRespository : IEnquiryService
{
    private readonly AppDbContext _context;
    // Constructor that initializes the repository with the application database context.
    public EnquiryRespository(AppDbContext context)
    {
        _context = context;
    }
    // Method to create a new enquiry in the database.
 
    public void Create(Enquiry enquiry)
    {
        _context.Enquiries.Add(enquiry);
        _context.SaveChanges();
    }
    // Method to retrieve a list of enquiries associated with a specific student by their ID.
 
    public List<MyEnquiries> MyEnquiries(int id)
    {
        var data = _context.StudentEnquiries.FromSqlInterpolated($"SP_MyEnquiries {id}").ToList();
        return data;
    }
    // Method to retrieve all enquiries related to a specific course by its ID.
    public List<Enquiry> GetEnquiriesByCourseId(int id){
            var data=_context.Enquiries.Where(x=>x.courseId==id).ToList();
            return data;
        }
        // Method to retrieve a specific enquiry by its enquiry ID.
        

        public Enquiry GetEnquiryByEnquiryId(int id){
            var data=_context.Enquiries.FirstOrDefault(x=>x.enquiryId==id);
            return data;
       }
       // Method to update the status and response of an existing enquiry.
       public void Update(int id,Enquiry enquiry){
            var data=this.GetEnquiryByEnquiryId(id);
            data.status=enquiry.status;
            data.response=enquiry.response;
            _context.Enquiries.Update(data);
            _context.SaveChanges();
       }
}
 