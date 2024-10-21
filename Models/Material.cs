using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Data;
namespace MVC_EduHub_Project.Models;

public class Material
{
    public int materialId {get; set;}
    public int courseId  {get; set;}
    public string title  {get; set;}
    public string description {get; set;}
    public string URL  {get; set;}
    public DateTime uploadDate  {get; set;}
    public string contentType {get; set;}





}