namespace MovieTracking.Domain.Entities;

public class Movie
{
    public required int Id { get; set; }
    public required string Title { get; set; }
    public required string Overview { get; set; }
    public int Runtime { get; set; }
    public DateOnly ReleaseDate { get; set; }
    public List<List> Lists { get; set; } = [];
    public List<ListMovie> ListMovies { get; } = [];
}