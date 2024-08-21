var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/FirstName/Alireza", () => "FirstName is Alireza");
app.MapGet("/FirstName/Mohammad", () => "FirstName is Mohammad");
app.MapGet("/{FirstName}/{LastName}", async (httpcontext) => { 
    var values = httpcontext.Request.RouteValues;
    var firstName = values["FirstName"];

    foreach (var item in values)
    {
        await httpcontext.Response.WriteAsync($"Key is: {item.Key} and value is: {item.Value} \r");

    }
});
//app.MapGet("/{Name}/{Family}", () => "Name and Family is Dynamic");
app.MapGet("/", () => "Hello World!");

app.Run();
