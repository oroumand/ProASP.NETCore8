var builder = WebApplication.CreateBuilder(args);
builder.Configuration.Sources.Clear();
builder.Configuration.AddJsonFile("appsettings.json");
//builder.Configuration.AddEnvironmentVariables();
builder.Configuration.AddEnvironmentVariables("Configuratoin");
var app = builder.Build();

app.MapGet("/", () => app.Configuration.AsEnumerable());

app.Run();
