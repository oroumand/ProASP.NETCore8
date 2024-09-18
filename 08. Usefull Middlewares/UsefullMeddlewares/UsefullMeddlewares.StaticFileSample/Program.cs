using Microsoft.Extensions.FileProviders;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();
app.UseStaticFiles();
app.UseStaticFiles(new StaticFileOptions
{
    FileProvider = new PhysicalFileProvider($"{app.Environment.ContentRootPath}/myfile"),
    RequestPath = "/myfile",
    
});
app.MapGet("/", () => "Hello World!");

app.Run();
