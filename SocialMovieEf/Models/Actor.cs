using System;
using System.Collections.Generic;

namespace SocialMovieEf.Models;

public partial class Actor
{
    public int Id { get; set; }

    public string Lastname { get; set; } = null!;

    public string Firstname { get; set; } = null!;

    public bool IsActive { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual ICollection<MovieActor> MovieActors { get; set; } = new List<MovieActor>();
}
