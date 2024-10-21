using MVC_EduHub_Project.Models;

namespace MVC_EduHub_Project.Services;

public interface IUserService

{
    User CreateUser(User newuser);
    User Login(LoginViewModel loginuser);
}