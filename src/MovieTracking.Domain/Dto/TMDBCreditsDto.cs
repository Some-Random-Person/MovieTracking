namespace MovieTracking.Domain.Dto;

public sealed record TMDBCreditsDto(int Id, List<TMDBActorDto> Cast, List<TMDBCrewDto> Crew);