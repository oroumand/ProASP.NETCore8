using DISample.Facory;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddScoped<IntReposiory>();
builder.Services.AddScoped<DateTimeRepository>();

builder.Services.AddScoped<IRepository>(serviceProvider =>
{
    DateTime dt = DateTime.Now;
    if(dt.Hour >=8 && dt.Hour <=10)
    {
        return serviceProvider.GetRequiredService<IntReposiory>();
        
    }
    return new DateTimeRepository();
});
var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.Run();
