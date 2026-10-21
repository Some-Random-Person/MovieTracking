namespace MovieTracking.Domain.Dto;

public sealed record ImagesDto(int Id, List<ImageDto> Backdrops, List<ImageDto> Logos, List<ImageDto> Posters);