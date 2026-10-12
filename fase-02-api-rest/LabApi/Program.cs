using Scalar.AspNetCore;
using Confluent.Kafka;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddSingleton<IProducer<Null, string>>(_ =>
new ProducerBuilder<Null, string>(new ProducerConfig {BootstrapServers = "localhost:9092"}).Build()
);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
        app.MapScalarApiReference();
}

app.UseHttpsRedirection();

var summaries = new[]
{
    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
};


app.MapGet("/integrations/status", async (IProducer<Null, string> producer) =>
{
    var checkedAt = DateTime.UtcNow;

    await producer.ProduceAsync("lab-events",
        new Message<Null, string> { Value = $"status consultado a las {checkedAt:O}" });

    return new
    {
        service = "LabApi",
        status = "running",
        checkedAt
    };
})
.WithName("GetIntegrationStatus")
.WithTags("Integrations");

app.Run();

record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}
