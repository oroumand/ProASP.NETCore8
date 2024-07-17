var builder = WebApplication.CreateBuilder(args);

builder.Services.
    AddHttpLogging
    (c =>
    c.LoggingFields = Microsoft.AspNetCore.HttpLogging.HttpLoggingFields.RequestProperties);


builder.Logging.AddFilter("Microsoft.AspNetCore.HttpLogging", LogLevel.Information);


var app = builder.Build();

app.UseHttpLogging();

app.MapGet("/", () => "Hello World!");
app.MapGet("/person", () => new Person("Alireza", "Oroumand"));

app.Run();


public record Person(string FirstName, string LastName);
