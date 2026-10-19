namespace MovieTracking.Infrastructure.TMDB.Dto;

public sealed record ActorDto(bool Adult, int Gender, int Id, string Known_for_department, string Name, string Original_name, decimal Popularity, string Profile_path, int Cast_id, string Character, string Credit_id, int Order);