using Microsoft.EntityFrameworkCore.Metadata.Internal;

using MVC_EduHub_Project.Models;
using MVC_EduHub_Project.Services;
 
namespace MVC_EduHub_Project.Repository;
 
public class UserRepository : IUserService
{
    private readonly AppDbContext _context;
    public UserRepository(AppDbContext context)
    {
        _context = context;
    }
 
    public User CreateUser(User newuser)
    {
        _context.Users.Add(newuser);
        _context.SaveChanges();
        return newuser;
    }
 
 
    public User Login(LoginViewModel loginuser)
    {
        var user = _context.Users.Where(x => x.UserName == loginuser.UserName && x.Password == loginuser.Password).FirstOrDefault();
        return user;
    }
}

