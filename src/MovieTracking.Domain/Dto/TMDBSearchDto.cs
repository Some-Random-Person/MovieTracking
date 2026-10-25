namespace MovieTracking.Domain.Dto;

public sealed record TMDBSearchDto(int Page, List<TMDBMovieDto> Results, int Total_pages, int Total_results);