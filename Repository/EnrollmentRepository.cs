using System.Security.Claims;
using System.Security.Principal;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MVC_EduHub_Project.Models;
using MVC_EduHub_Project.Services;
using MVC_EduHub_Project.ViewModels;
 
namespace MVC_EduHub_Project.Repository;
public class EnrollmentRepository : IEnrollmentService
{
    private readonly AppDbContext _context;
    public EnrollmentRepository(AppDbContext context)
    {
        _context = context;
    }
 
    public void Create(Enrollment enrollment)
    {
        _context.Enrollments.Add(enrollment);
        _context.SaveChanges();
    }
 
    public List<EnrollmentViewModel> EnrolledStudents(int id)
    {
        var data =  _context.EnrolledStudents.FromSqlInterpolated($"SP_EnrolledStudent {id}").ToList();
        return data;
    }
 
    public List<EnrollmentViewModel> PendingStudents(int id)
    {
        var data =  _context.EnrolledStudents.FromSqlInterpolated($"SP_EnrolledStudent {id}").AsEnumerable().Where(x=>x.Status=="Pending").ToList();
        return data;
    }
 
    public List<EnrollmentByStudent> StudentEnrollments(int id)
    {
        var data = _context.EnrollmentByStudents.FromSqlInterpolated($"SP_EnrollmentByStudent {id}").ToList();
        return data;
    }
 
    public void UpdateToAccept(int id)
    {
        var data = _context.Enrollments.FirstOrDefault(x=>x.enrollmentId==id);
        data.status = "Accepted";
        _context.Enrollments.Update(data);
        _context.SaveChanges();
    }
    public void UpdateToReject(int id)
    {
        var data = _context.Enrollments.FirstOrDefault(x=>x.enrollmentId==id);
        data.status = "Rejected";
        _context.Enrollments.Update(data);
        _context.SaveChanges();
    }
}
 