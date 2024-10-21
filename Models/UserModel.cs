using System;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MVC_EduHub_Project.Models;
namespace MVC_EduHub_Project.Models;

public class UserModel
{
    [Key]
    public int UserId  { get; set; }
    [DisplayName("User name")]
    [Required(ErrorMessage="Userame is compulsory")]
    public  string UserName { get; set; }
    [DataType(DataType.Password)]
    public  string Password { get; set; }
    // [DataType(DataType.Password)]
    // [Compare("Password",ErrorMessage = "Password and Confirmation Password must match,")]
    // public string ConfirmPassword {get; set;}
    public  string role { get; set; }
    [EmailAddress(ErrorMessage="Enter valid email Format")]
    public string  email { get; set; }
    [Phone(ErrorMessage ="Enter valid Mobile Number")]
    public string mobileNumber  { get; set; }
    public IFormFile Photo  { get; set; }


}