var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Hello World!");
app.MapGet("/fullName", (IConfiguration configuration) =>
{
    string firstName = configuration["FirstName"];
    string lastName = configuration["LastName"];
    return $"{firstName} {lastName}";
});
app.Run();
