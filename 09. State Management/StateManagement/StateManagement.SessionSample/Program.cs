using System.Text.Json;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(c =>
{
    c.IdleTimeout = TimeSpan.FromSeconds(30);
    c.Cookie.IsEssential = true;
    c.Cookie.HttpOnly = true;
});
var app = builder.Build();
app.UseSession();

app.MapGet("/", () => "Hello World!");


app.MapGet("/session", async httpcontext =>
{

    int counter1 = httpcontext.Session.GetInt32("Counter1") ?? 0;
    int counter2 = httpcontext.Session.GetInt32("Counter2") ?? 0;
    counter1++;
    counter2++;
    string counter1String = JsonSerializer.Serialize(counter1);
    string counter2String = JsonSerializer.Serialize(counter2);

    var counter1Byte = System.Text.Encoding.UTF8.GetBytes(counter1String);
    var counter2Byte = System.Text.Encoding.UTF8.GetBytes(counter2String);

    httpcontext.Session.Set("Counter1", counter1Byte);
    httpcontext.Session.Set("Counter1", counter2Byte);


    await httpcontext.Response.WriteAsync($"Counter 01: {counter1} Counter 02: {counter2}");
});

app.Run();
