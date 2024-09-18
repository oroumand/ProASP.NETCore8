using Microsoft.AspNetCore.HttpLogging;
using Microsoft.Extensions.FileProviders;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddHttpLogging(c =>
{
    c.LoggingFields = HttpLoggingFields.Request|HttpLoggingFields.Response;
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
app.UseHttpLogging();
app.UseHttpsRedirection();
app.UseStaticFiles(

    new StaticFileOptions
    {
        FileProvider = new PhysicalFileProvider(""),
        RequestPath = ""
    }
);

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
