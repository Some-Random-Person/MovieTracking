namespace MovieTracking.Infrastructure.TMDB.Dto;

public sealed record CrewDto(bool Adult, int Gender, int Id, string Known_for_department, string Name, string Original_name, decimal Popularity, string Profile_path, string Credit_id, string Department, string Job);