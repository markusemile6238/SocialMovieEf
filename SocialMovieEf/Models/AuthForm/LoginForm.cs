using System.ComponentModel.DataAnnotations;

namespace SocialMovieEf.Models.AuthForm;

public class LoginForm
{
    [Required (ErrorMessage = "Please enter a username and password")]
    public string Email { get; set; } = string.Empty;
    
    [Required (ErrorMessage = "Please enter a password")]
    public string Password { get; set; } = string.Empty;
}