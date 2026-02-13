

using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Identity;
using SocialMovieEf.Models;
using SocialMovieEf.Models.UserForm;

namespace SocialMovieEf.Components.Pages.Auth;

public partial class Register
{
    [Inject] private UserManager<User> UserManager { get; set; } = null!;

    private NavigationManager Nav { get; set; } = null!;
    
    private CreateUser _newUser = new ();
    private string _error = "";

    public async Task RegisterAsync()
    {
        var user = new User
        {
            UserName = _newUser.Email,
            Email = _newUser.Email,
            Firstname = _newUser.Firstname,
            Lastname = _newUser.Lastname,
            IsActive = true,
            CreatedAt = DateTime.UtcNow
        };
        var result = await UserManager.CreateAsync(user, _newUser.Password);

        if (result.Succeeded)
        {
            Nav.NavigateTo("/login");
        }
        else
        {
            _error = string.Join(", ", result.Errors.Select(x => x.Description));
        }
    }
    
}