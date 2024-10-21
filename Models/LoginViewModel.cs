using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
namespace MVC_EduHub_Project.Models;

public class LoginViewModel
{
    [Key]
    public string? UserName {get; set;}
    
    [Required]
    [MinLength(8)]
    [DataType(DataType.Password)]
    public string? Password {get; set;}

    
}