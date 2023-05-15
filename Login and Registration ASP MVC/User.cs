#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace MyProject.Models;
public class User
{
    [Key]
    public int UserId { get; set; }

    [Required(ErrorMessage = "is required.")]
    public string FirstName {get;set;}

    [Required(ErrorMessage = "is required.")]
    public string LastName {get;set;}

    [Required(ErrorMessage = "is required.")]
    [UniqueEmail]
    [EmailAddress]
    public string Email {get;set;}

    [Required(ErrorMessage = "is required.")]
    [DataType(DataType.Password)]
    public string Password {get;set;}

    [Required(ErrorMessage = "is required.")]
    [DataType(DataType.Password)]
    //"ConfirmPassword exists only to ensure the password was typed in correctly. It does not get pushed to SQL.
    [NotMapped]  
    [Compare("Password")]
    public string ConfirmPassword {get;set;}

    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;
}

//Custom validation to ensure the email address doesn't already exist in the system.
public class UniqueEmailAttribute : ValidationAttribute
{
    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        if(value == null)
        {
            return new ValidationResult("is required!");
        }
        MyContext _context = (MyContext)validationContext.GetService(typeof(MyContext));
    	if(_context.Users.Any(e => e.Email == value.ToString()))
        {
            return new ValidationResult("is already in use.");
        } else {
            return ValidationResult.Success;
        }
    }
}