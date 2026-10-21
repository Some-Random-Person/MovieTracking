using MovieTracking.Domain.Interfaces;
using MovieTracking.Infrastructure.TMDB;

var builder = WebApplication.CreateBuilder(args);

var tmdbToken = builder.Configuration["Tmdb:AccessToken"] ?? throw new InvalidOperationException("Tmdb:AccessToken is not configured");

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddSingleton<IMovieClient>(new MovieClient(tmdbToken));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();

    app.UseSwaggerUI(options =>
    {
        options.RoutePrefix = "docs";
        options.SwaggerEndpoint("/openapi/v1.json", "v1");
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
