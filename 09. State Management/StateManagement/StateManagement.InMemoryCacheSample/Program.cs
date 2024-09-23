using Microsoft.Extensions.Caching.Memory;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddMemoryCache();
var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.MapGet("/set", async (HttpContext context, IMemoryCache cache) =>
{
    List<string> news = ["First News", "Seccond News", "..."];
    MemoryCacheEntryOptions options = new MemoryCacheEntryOptions
    {
        AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(15),
        SlidingExpiration = TimeSpan.FromMinutes(2)
    };
    cache.Set("News", news, options);
    await context.Response.WriteAsync("Cache Set");
});

app.MapGet("/get", async (HttpContext context, IMemoryCache cache) =>
{
    var news = cache.Get<List<string>>("News");
    await context.Response.WriteAsync(string.Join(",", news));
});
app.Run();
