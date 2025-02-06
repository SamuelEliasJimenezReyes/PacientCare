using Carter;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Routing;
namespace PatientCare.Presentation.EndPoints;

public class WeatherForecastEndPoint() : CarterModule("/weatherforecast")
{
    public override void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/", () =>
        {
            var summaries = new[]
            {
                "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
            };

            var forecast = Enumerable.Range(1, 5).Select(index =>
                    new WeatherForecast
                    (
                        DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                        Random.Shared.Next(-20, 55),
                        summaries[Random.Shared.Next(summaries.Length)]
                    ))
                .ToArray();
        });
        app.MapPost("/create",SayHi);
    }

    public record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
    {
        public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
    }

    private static Results<Ok , NotFound> SayHi(string name)
    {
        return (Results<Ok, NotFound>)(Results.Ok($"Hello, {name}") ?? Results.NotFound());
    }
}