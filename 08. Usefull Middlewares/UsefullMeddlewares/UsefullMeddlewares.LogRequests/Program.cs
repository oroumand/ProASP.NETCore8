using Microsoft.AspNetCore.HttpLogging;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddHttpLogging(c =>
{
    c.LoggingFields = HttpLoggingFields.Request | HttpLoggingFields.Response;
});
var app = builder.Build();


app.UseHttpLogging();
app.MapGet("/", () => "Hello World!");

app.Run();
