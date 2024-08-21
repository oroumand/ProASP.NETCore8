var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Hello World!");
app.MapFallback(async (httpcontext) =>
{
    await httpcontext.Response.WriteAsync("Not Found");
});
app.Run();
