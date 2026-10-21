namespace MovieTracking.Domain.Dto;

public sealed record CollectionDto(int Id, string Name, string? Poster_path, string? Backdrop_path);