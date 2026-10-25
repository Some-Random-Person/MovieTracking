namespace MovieTracking.Domain.Entities;

public class List
{
    public Guid Id { get; set; }
    public required string Name { get; set; }
    public List<Movie> Movies {get; set; } = [];
    public List<ListMovie> ListMovies { get; } = [];
    public List<ListHierarchy> ParentLists { get; set; } = [];
    public List<ListHierarchy> ChildLists { get; set; } = [];
}