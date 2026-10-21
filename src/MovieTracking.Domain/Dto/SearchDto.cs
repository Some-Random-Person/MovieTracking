namespace MovieTracking.Domain.Dto;

public sealed record SearchDto(int Page, List<MovieDto> Results, int Total_pages, int Total_results);