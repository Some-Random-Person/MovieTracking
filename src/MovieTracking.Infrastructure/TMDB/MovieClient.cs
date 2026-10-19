using System.Diagnostics;
using System.Net;
using System.Net.Http.Json;
using System.Text.Json;

namespace MovieTracking.Infrastructure.TMDB;

public class MovieClient
{
    private static readonly TimeSpan MinimumInterval = TimeSpan.FromMilliseconds(700);
    private static readonly TimeSpan DefaultRetryDelay = TimeSpan.FromMinutes(1);
    private const int MaxAttempts = 3;

    private static readonly JsonSerializerOptions JsonOptions = new()
    {
        PropertyNamingPolicy = JsonNamingPolicy.SnakeCaseLower,
        RespectNullableAnnotations = true,
        RespectRequiredConstructorParameters = true,
    };

    private readonly HttpClient _httpClient = new()
    {
        BaseAddress = new Uri("https://api.themoviedb.org/3/"),
        DefaultRequestHeaders = { { "User-Agent", "MovieTracking/0.1 (+https://github.com/Some-Random-Person/MovieTracking)"}}
    };
    private readonly SemaphoreSlim _lock = new(1, 1);
    private readonly Stopwatch _sinceLastCall = new();

    private async Task<T> GetAsync<T>(string path, CancellationToken cancellationToken)
    {
        await _lock.WaitAsync(cancellationToken);

        try
        {
            for (var attempt = 1; ; attempt++)
            {
                if (_sinceLastCall.IsRunning && _sinceLastCall.Elapsed < MinimumInterval)
                {
                    await Task.Delay(MinimumInterval - _sinceLastCall.Elapsed, cancellationToken);
                }

                using var response = await _httpClient.GetAsync(path, cancellationToken);
                _sinceLastCall.Restart();

                if (response.StatusCode == HttpStatusCode.TooManyRequests && attempt < MaxAttempts)
                {
                    await Task.Delay(response.Headers.RetryAfter?.Delta ?? DefaultRetryDelay, cancellationToken);
                    continue;
                }

                response.EnsureSuccessStatusCode();
                return await response.Content.ReadFromJsonAsync<T>(JsonOptions, cancellationToken) ?? throw new InvalidOperationException($"Empty response from {path}");
            }
        }
        finally
        {
            _lock.Release();
        }
    }
}