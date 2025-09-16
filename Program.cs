var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// Our Hello World endpoints (without WithOpenApi)
app.MapGet("/", () => "Hello World from ASP.NET Core!")
    .WithName("GetHelloWorld");

app.MapGet("/health", () => new {
    Status = "Healthy",
    Timestamp = DateTime.UtcNow,
    Version = "1.0.0"
})
    .WithName("GetHealth");

app.MapGet("/api/info", () => new {
    Application = "Hello World API",
    Version = "1.0.0",
    Environment = app.Environment.EnvironmentName,
    MachineName = Environment.MachineName
})
    .WithName("GetInfo");

app.Run();

// Make the implicit Program class public so test projects can access it
public partial class Program { }