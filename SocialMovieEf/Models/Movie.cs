using System;
using System.Collections.Generic;

namespace SocialMovieEf.Models;

public partial class Movie
{
    public int Id { get; set; }

    public string Title { get; set; } = null!;

    public string Synopsis { get; set; } = null!;

    public int ReleaseYear { get; set; }

    public string? PosterUrl { get; set; }

    public string? WallpaperUrl { get; set; }

    public bool IsActive { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual ICollection<MovieActor> MovieActors { get; set; } = new List<MovieActor>();

    public virtual ICollection<Gender> Genders { get; set; } = new List<Gender>();
}
