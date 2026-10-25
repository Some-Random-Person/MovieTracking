using Microsoft.EntityFrameworkCore;
using MovieTracking.Domain.Entities;

namespace MovieTracking.Infrastructure;

public class MovieTrackingDbContext : DbContext
{
    public MovieTrackingDbContext(DbContextOptions<MovieTrackingDbContext> options) : base(options)
    {
        
    }

    public DbSet<Movie> Movies { get; set; }
    public DbSet<List> Lists { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Movie>()
            .HasMany(e => e.Lists)
            .WithMany(e => e.Movies)
            .UsingEntity<ListMovie>();

        modelBuilder.Entity<ListHierarchy>(e =>
        {
            e.HasKey(e => new {e.ChildListId, e.ParentListId});

            e.HasOne(e => e.ParentList)
                .WithMany(e => e.ChildLists)
                .HasForeignKey(e => e.ParentListId)
                .OnDelete(DeleteBehavior.Restrict);

            e.HasOne(e => e.ChildList)
                .WithMany(e => e.ParentLists)
                .HasForeignKey(e => e.ChildListId)
                .OnDelete(DeleteBehavior.Restrict);
        });
    }
}
