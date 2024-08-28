var builder = WebApplication.CreateBuilder(args);
builder.Configuration.Sources.Clear();
builder.Configuration.AddUserSecrets("e0ad4648-7698-4ffb-a0c1-4ca006abd3d0");
var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.Run();
