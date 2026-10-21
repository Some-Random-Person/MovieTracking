namespace MovieTracking.Domain.Dto;

public sealed record CreditsDto(int Id, List<ActorDto> Cast, List<CrewDto> Crew);