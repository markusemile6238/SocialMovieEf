using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SocialMovieEf.Models;

namespace SocialMovieEf.Common;

public partial class SmContext : IdentityDbContext<User, IdentityRole<int>, int>
{

    public SmContext(DbContextOptions<SmContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Actor> Actors { get; set; }

    public virtual DbSet<Gender> Genders { get; set; }

    public virtual DbSet<Movie> Movies { get; set; }

    public virtual DbSet<MovieActor> MovieActors { get; set; }

    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
        modelBuilder.Entity<Actor>(entity =>
        {
            entity.Property(e => e.Firstname).HasMaxLength(80);
            entity.Property(e => e.Lastname).HasMaxLength(80);
        });

        modelBuilder.Entity<Gender>(entity =>
        {
            entity.HasIndex(e => e.Name, "IX_Genders_Name").IsUnique();

            entity.Property(e => e.Name).HasMaxLength(50);

            entity.HasMany(d => d.Movies).WithMany(p => p.Genders)
                .UsingEntity<Dictionary<string, object>>(
                    "MovieGender",
                    r => r.HasOne<Movie>().WithMany().HasForeignKey("MoviesId"),
                    l => l.HasOne<Gender>().WithMany().HasForeignKey("GendersId"),
                    j =>
                    {
                        j.HasKey("GendersId", "MoviesId");
                        j.ToTable("MovieGenders");
                        j.HasIndex(new[] { "MoviesId" }, "IX_MovieGenders_MoviesId");
                    });
        });

        modelBuilder.Entity<Movie>(entity =>
        {
            entity.HasIndex(e => new { e.Title, e.ReleaseYear }, "IX_Movies_Title_ReleaseYear").IsUnique();

            entity.Property(e => e.Title).HasMaxLength(150);
        });

        modelBuilder.Entity<MovieActor>(entity =>
        {
            entity.HasKey(e => new { e.MovieId, e.ActorId });

            entity.HasIndex(e => e.ActorId, "IX_MovieActors_ActorId");

            entity.Property(e => e.RoleName).HasMaxLength(100);

            entity.HasOne(d => d.Actor).WithMany(p => p.MovieActors).HasForeignKey(d => d.ActorId);

            entity.HasOne(d => d.Movie).WithMany(p => p.MovieActors).HasForeignKey(d => d.MovieId);
        });

        modelBuilder.Entity<User>(entity =>
        {

            entity.Property(e => e.Firstname).HasMaxLength(80);
            entity.Property(e => e.Lastname).HasMaxLength(80);

            entity.ToTable("Users");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
