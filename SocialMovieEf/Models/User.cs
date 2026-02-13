using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace SocialMovieEf.Models;

public partial class User : IdentityUser<int>
{
  
    public string Firstname { get; set; } = null!;

    public string Lastname { get; set; } = null!;

    public bool IsActive { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }
}
