namespace MovieTracking.Domain.Dto;

public sealed record TMDBImageDto(decimal Aspect_ratio, int Height, string? Iso_639_1, string File_path, decimal Vote_average, int Vote_count, int Width);