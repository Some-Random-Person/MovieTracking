using MovieTracking.Domain.Dto;

namespace MovieTracking.Domain.Interfaces;

public interface IMovieClient
{
    Task<List<MovieDto>> GetMovieSearch(string Query, CancellationToken cancellationToken = default);
    Task<MovieDetailsDto> GetMovieDetails(int id, CancellationToken cancellationToken = default);
}