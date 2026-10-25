using MovieTracking.Domain.Dto;

namespace MovieTracking.Domain.Interfaces;

public interface IMovieClient
{
    Task<List<TMDBMovieDto>> GetMovieSearch(string Query, CancellationToken cancellationToken = default);
    Task<TMDBMovieDetailsDto> GetMovieDetails(int id, CancellationToken cancellationToken = default);
}