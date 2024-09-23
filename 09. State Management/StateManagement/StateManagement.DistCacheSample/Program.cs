using Microsoft.Extensions.Caching.Distributed;
using System.Text.Json;

var builder = WebApplication.CreateBuilder(args);
//builder.Services.AddDistributedMemoryCache();
builder.Services.AddDistributedSqlServerCache(c =>
{
    c.SchemaName = "dbo";
    c.TableName = "DataCache";
    c.ConnectionString = "Server=.;Database=CacheDb; User Id=sa; Password=1qaz!QAZ; TrustServerCertificate=True";
});
var app = builder.Build();

app.MapGet("/", () => "Hello World!");
app.MapGet("/set", async (HttpContext context, IDistributedCache cache) =>
{
    List<string> news = ["First News", "Seccond News", "..."];
    DistributedCacheEntryOptions options = new()
    {
        AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(15),
        SlidingExpiration = TimeSpan.FromMinutes(2)
    };
    string newsString = JsonSerializer.Serialize(news);
    var newsBytes = System.Text.Encoding.UTF8.GetBytes(newsString);
    cache.Set("News", newsBytes, options);
    await context.Response.WriteAsync("Cache Set");
});

app.MapGet("/get", async (HttpContext context, IDistributedCache cache) =>
{
    var newsBytes = cache.Get("News");
    var newsString = System.Text.Encoding.UTF8.GetString(newsBytes);
    var news = JsonSerializer.Deserialize<List<string>>(newsString);
    await context.Response.WriteAsync(string.Join(",", news));
});
app.Run();
