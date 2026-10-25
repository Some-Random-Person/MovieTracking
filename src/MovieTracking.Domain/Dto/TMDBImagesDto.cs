namespace MovieTracking.Domain.Dto;

public sealed record TMDBImagesDto(int Id, List<TMDBImageDto> Backdrops, List<TMDBImageDto> Logos, List<TMDBImageDto> Posters);