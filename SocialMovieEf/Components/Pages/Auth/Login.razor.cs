using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Identity;
using SocialMovieEf.Models;
using SocialMovieEf.Models.AuthForm;
using SocialMovieEf.Services;

namespace SocialMovieEf.Components.Pages.Auth;

public partial class Login
{
    [Inject] private UserServices UserServices { get; set; } = null!;
    [Inject] private NavigationManager Nav { get; set; } = null!;
    [Inject] private SignInManager<User> SignInManager { get; set; } = null!;

    private LoginForm _loginForm = new (); 
    private string _error = "";

    public async Task LoginAsync()
    {
        var result = await SignInManager.PasswordSignInAsync(
            _loginForm.Email,
            _loginForm.Password,
            isPersistent: true,
            lockoutOnFailure: false);
        if (result.Succeeded)
        {
            Nav.NavigateTo("/");
        }
        else
        {
            _error = "Email and password association not correct";
        }
    }

}