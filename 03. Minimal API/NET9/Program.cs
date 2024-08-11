var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => TypedResults.InternalServerError("What's New IN ASP.NET Core 9?!"));

app.Run();
