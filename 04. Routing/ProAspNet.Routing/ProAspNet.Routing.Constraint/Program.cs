using ProAspNet.Routing.Constraint;

var builder = WebApplication.CreateBuilder(args);
builder.Services.Configure<RouteOptions>(options =>
{
    options.ConstraintMap.Add("ssn",typeof(NationalNumberConstraint));  
});
var app = builder.Build();

app.MapGet("/", () => "Hello World!");


app.MapGet("/{firstName:alpha:minlength(2):maxlength(10)}/{lastName:alpha:minlength(2):maxlength(10)}", async (context) =>
{
    string firstName = context.Request.RouteValues["firstName"] as string ?? "NoName";
    string lastName = context.Request.RouteValues["lastName"] as string ?? "NoName";
    await context.Response.WriteAsync($"{firstName} {lastName}");
});

app.MapGet("/{NationalNumber:ssn}", async (context) =>
{
    var nationalNumber = context.Request.RouteValues["NationalNumber"];
    await context.Response.WriteAsync(nationalNumber.ToString());
});
app.Run();
