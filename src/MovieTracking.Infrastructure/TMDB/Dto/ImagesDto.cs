namespace MovieTracking.Infrastructure.TMDB.Dto;

public sealed record ImagesDto(int Id, List<MovieDto> Backdrops, List<MovieDto> Logos, List<MovieDto> Posters);