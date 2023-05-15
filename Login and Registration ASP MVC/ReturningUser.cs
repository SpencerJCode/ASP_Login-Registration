#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace MyProject.Models;
public class ReturningUser
{
    [Key]
    public int ReturningUserId { get; set; }
    [Required(ErrorMessage = "is required.")]
    public string ReturningEmail {get;set;}
    [Required(ErrorMessage = "is required.")]
    [DataType(DataType.Password)]
    public string ReturningPassword {get;set;}
    
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;
}