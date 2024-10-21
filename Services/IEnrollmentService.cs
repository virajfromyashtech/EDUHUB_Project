using MVC_EduHub_Project.Models;
using MVC_EduHub_Project.ViewModels;
 
namespace MVC_EduHub_Project.Services;
public interface IEnrollmentService
{
     List<EnrollmentViewModel> EnrolledStudents(int id);
     List<EnrollmentViewModel> PendingStudents(int id);
     void UpdateToAccept(int id);
     void UpdateToReject(int id);
     List<EnrollmentByStudent> StudentEnrollments(int id);
     void Create(Enrollment enrollment);
}
 