var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Hello World!");
app.MapGet("/{f1}/{*f2}", async (context) =>
{
    await context.Response.WriteAsync("list of Segments");
    foreach (var item in context.Request.RouteValues)
    {
        await context.Response.WriteAsync($"{item.Key}: {item.Value}{Environment.NewLine}");
    }

});

app.Run();
