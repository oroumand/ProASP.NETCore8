using System.Diagnostics.Metrics;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.MapGet("/cookies", async httpcontext =>
{
    var options = new CookieOptions
    {
        MaxAge = TimeSpan.FromMinutes(60)
    };
    int counter1 = int.Parse(httpcontext.Request.Cookies["Counter1"] ?? "0");
    int counter2 = int.Parse(httpcontext.Request.Cookies["Counter2"] ?? "0");
    counter1++;
    counter2++;

    httpcontext.Response.Cookies.Append("Counter1", counter1.ToString(), options);
    httpcontext.Response.Cookies.Append("Counter2", counter2.ToString(), options);

    await httpcontext.Response.WriteAsync($"Counter 01: {counter1} Counter 02: {counter2}");
});

app.MapGet("/cookies/delete", async httpcontext =>
{
    httpcontext.Response.Cookies.Delete("Counter1");
    httpcontext.Response.Cookies.Delete("Counter2");

    await httpcontext.Response.WriteAsync("Delte All Cookies");

});
app.MapGet("/cookies/clear", async httpcontext =>
{
    var keyes = httpcontext.Request.Cookies.Keys.ToList();
    foreach (var key in keyes)
    {
        httpcontext.Response.Cookies.Delete(key);
    }
    await httpcontext.Response.WriteAsync("Delte All Cookies");

});
app.Run();


