namespace MovieTracking.Domain.Dto;

public sealed record TMDBCollectionDto(int Id, string Name, string? Poster_path, string? Backdrop_path);