using Microsoft.AspNetCore.Http;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.UseRouting();

app.Run(async c =>
{
    var endpoint = c.GetEndpoint();
    endpoint.de
    if(endpoint is not null )
        await c.Response.WriteAsync(endpoint.DisplayName ?? "NoName");
});
app.MapGet("/", () => "Hello World!");

app.MapGet("/{number:int}", async (context) =>
{
    await context.Response.WriteAsync($"Number is {context.Request.RouteValues["number"]}");
}).WithDisplayName("Integer Number").Add(c => ((RouteEndpointBuilder)c).Order = 1);
app.MapGet("/{numberDecimal:double}", async (context) =>
{
    await context.Response.WriteAsync($"Number is {context.Request.RouteValues["numberDecimal"]}");
}).WithDisplayName("Decimal Number").Add(c => ((RouteEndpointBuilder)c).Order = 2);
app.Run();
