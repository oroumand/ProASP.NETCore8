var builder = WebApplication.CreateBuilder(args);
builder.Configuration.Sources.Clear();  
builder.Configuration.AddJsonFile("Appsetting.json",optional:true,reloadOnChange:true);
var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.Run();
