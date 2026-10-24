namespace MovieTracking.Domain.Entities;

public class ListMovie
{
    public Guid ListId { get; set; }
    public int MovieId { get; set; }
    public required List List { get; set; }
    public required Movie Movie { get; set; }
    public int? SortingNumber { get; set; }
}