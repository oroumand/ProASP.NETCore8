var builder = WebApplication.CreateBuilder(args);
builder.Configuration.Sources.Clear();
builder.Configuration.AddJsonFile("MySetting.json", true);

var ConfigSource = builder.Configuration.Sources;
var fullName = builder.Configuration["FullName"];
var School = builder.Configuration["SchoolName"];
var app = builder.Build();

app.MapGet("/", () => "Hello World!");
app.MapGet("/fullName", (IConfiguration configuration) =>
{
    var section = configuration.GetSection("fullName");
    string firstName = section["FirstName"];
    string lastName = section["LastName"];
    return $"{firstName} {lastName}";
});
app.Run();
