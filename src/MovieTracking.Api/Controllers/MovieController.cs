using Microsoft.AspNetCore.Mvc;
using MovieTracking.Domain.Dto;
using MovieTracking.Domain.Interfaces;

namespace MovieTracking.Application.Controllers;

[Route("api/[controller]")]
[ApiController]
public class MovieController(IMovieClient movieClient) : ControllerBase
{
    private readonly IMovieClient _movieClient = movieClient;

    [HttpGet]
    public async Task<ActionResult<List<MovieDto>>> GetMovies(string query)
    {
        var results = await _movieClient.GetMovieSearch(query);
        return Ok(results);
    }

    [HttpGet("{movieId:int}")]
    public async Task<ActionResult<MovieDto>> GetMovie (int movieId)
    {
        var result = await _movieClient.GetMovieDetails(movieId);
        return Ok(result);
    }
}