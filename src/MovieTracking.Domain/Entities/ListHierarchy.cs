namespace MovieTracking.Domain.Entities;

public class ListHierarchy
{
    public Guid ParentListId { get; set; }
    public Guid ChildListId { get; set; }
    public required List ParentList { get; set; }
    public required List ChildList { get; set; }
    public int? SortingNumber { get; set; }
}