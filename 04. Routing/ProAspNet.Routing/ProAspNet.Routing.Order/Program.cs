var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Hello World!");
app.MapGet("/{number:int}", async (context) =>
{
    await context.Response.WriteAsync($"Number is {context.Request.RouteValues["number"]}");
}).Add(c=> ((RouteEndpointBuilder)c).Order = 1);
app.MapGet("/{numberDecimal:double}", async (context) =>
{
    await context.Response.WriteAsync($"Number is {context.Request.RouteValues["numberDecimal"]}");
}).Add(c => ((RouteEndpointBuilder)c).Order = 2);
app.Run();
