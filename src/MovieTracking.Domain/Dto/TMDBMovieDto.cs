namespace MovieTracking.Domain.Dto;

public sealed record TMDBMovieDto(bool Adult, string? Backdrop_path, List<int> Genre_ids, int Id, string Original_language, string Original_title, string Overview, decimal Popularity, string? Poster_path, string? Release_date, string Title, bool Video, decimal Vote_average, int Vote_count);