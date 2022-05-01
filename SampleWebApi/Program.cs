var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapGet("/weatherforecast", () =>
{
    var forecast = Enumerable.Range(1, 5)
    .Select(index =>
    {
        var tempF = Random.Shared.Next(-3, 105);
        return new WeatherForecast
        (
            GetUpcomingDate(index),
            tempF,
            TemperatureSummary(tempF)
        );
    }).ToArray();

    return forecast;
})
.WithName("GetWeatherForecast");

app.Run();

static string TemperatureSummary(int temperatureF) =>
    temperatureF switch
    {
        < 32 => "Freezing",
        < 40 => "Bracing",
        < 50 => "Chilly",
        < 60 => "Cool",
        < 70 => "Mild",
        < 80 => "Warm",
        < 90 => "Balmy",
        < 100 => "Hot",
        < 110 => "Sweltering",
        _ => "Scorching"
    };

static string GetUpcomingDate(int daysAhead)
{
    var dateOnly = DateOnly.FromDateTime(DateTime.Now.AddDays(daysAhead));
    return dateOnly.ToString();
}

internal record WeatherForecast(string Date, int TemperatureF, string? Summary)
{
}