namespace MovieTracking.Infrastructure.TMDB.Dto;

public sealed record CreditsDto(int Id, List<ActorDto> Cast, List<CrewDto> Crew);