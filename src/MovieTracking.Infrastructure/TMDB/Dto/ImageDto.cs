namespace MovieTracking.Infrastructure.TMDB.Dto;

public sealed record ImageDto(decimal Aspect_ratio, int Height, string Iso_639_1, string File_path, decimal Vote_average, int Vote_count, int Width);