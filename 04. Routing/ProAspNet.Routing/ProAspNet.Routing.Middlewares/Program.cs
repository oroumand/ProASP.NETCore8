using ProAspNet.Routing.Middlewares;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();
//app.UseRouting();

//app.UseMiddleware<CapitalMiddlewar>();
//app.UseMiddleware<PopulationMiddlewar>();
//app.MapGet("/", () => "Hello World!");
app.MapGet("/alireza", async (context) =>
{
    await context.Response.WriteAsync("My name is Alireza");
});
app.MapGet("/population/tehran", new PopulationMiddlewar().InvokeAsync);
//app.UseEndpoints(endpoints =>
//{

//});

app.Run(async d =>
{
    await d.Response.WriteAsync("Final Middleware");
});

//
app.Run();
