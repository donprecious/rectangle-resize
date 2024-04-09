using System.Text.Json;
using rectangleApi.Model;

var builder = WebApplication.CreateBuilder(args);


// Add services to the DI container.
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", builder =>
    {
        builder.AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader();
    });
});

var app = builder.Build();

app.UseHttpsRedirection();
app.UseCors("AllowAll");

var jsonFilePath = "Data/rectangle.json";

app.MapGet("/rectangle", async () =>
{
    if (!File.Exists(jsonFilePath))
    {
        return Results.NotFound("JSON file not found.");
    }

    string jsonString = await File.ReadAllTextAsync(jsonFilePath);
    var dimensions = JsonSerializer.Deserialize<RectangleDimension>(jsonString, new JsonSerializerOptions
    {
        PropertyNamingPolicy = JsonNamingPolicy.CamelCase
    });
    return Results.Ok(dimensions);
});

app.MapPut("/rectangle", async (RectangleDimension dimensions) =>
{
    var options = new JsonSerializerOptions { WriteIndented = true, PropertyNamingPolicy = JsonNamingPolicy.CamelCase };
    string jsonString = JsonSerializer.Serialize(dimensions, options);
    await File.WriteAllTextAsync(jsonFilePath, jsonString);
    return Results.Ok(dimensions);
});

app.MapGet("/rectangle/download", async () =>
{
    if (!File.Exists(jsonFilePath))
    {
        return Results.NotFound("JSON file not found.");
    }

    byte[] fileBytes = await File.ReadAllBytesAsync(jsonFilePath);
    return Results.File(fileBytes, "application/json", Path.GetFileName(jsonFilePath));
});

app.Run();