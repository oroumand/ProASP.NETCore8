var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Hello World!");
app.MapGet("/PrintFile/{FileName}.{FileExtensions}", async (context) =>
{
    var FileName = context.Request.RouteValues["filename"] as string;
    var FileExtension = context.Request.RouteValues["FileExtensions"] as string;

    await context.Response.WriteAsync(FileName);
    await context.Response.WriteAsync("     ");

    await context.Response.WriteAsync(FileExtension);

});
app.Run();
