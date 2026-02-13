using System.ComponentModel.DataAnnotations;

namespace SocialMovieEf.Models.UserForm;

public class CreateUser
{


    public string Firstname { get; set; } = null!;

    public string Lastname { get; set; } = null!;

    [Display(Name ="Email")]
    [Required(ErrorMessage ="Email is required")]
    [DataType(DataType.EmailAddress)]
    public string Email { get; set; } = null!;

    public string Password { get; set; } = null!;
    
}