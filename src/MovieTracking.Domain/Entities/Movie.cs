namespace MovieTracking.Domain.Entities;

public class Movie
{
    public required int Id { get; set; }
    public required string Backdrop_path { get; set; }
    public required string Overview { get; set; }
    public required string Title { get; set; }
    public required string Poster_path { get; set; }
    public bool Adult { get; set; }
}