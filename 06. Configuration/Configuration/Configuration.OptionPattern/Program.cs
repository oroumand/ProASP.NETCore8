using Configuration.OptionPattern;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);
//builder.Services.Configure<Personaldata>(builder.Configuration.GetSection("PersonalData"));
//Personaldata personaldata = new Personaldata();
//builder.Configuration.GetSection("PersonalData").Bind(personaldata);
//builder.Services.AddSingleton(personaldata);

builder.Services.Configure<Personaldata>(builder.Configuration.GetSection("PersonalData"));
builder.Services.AddSingleton(c => c.GetRequiredService<Personaldata>());
var app = builder.Build();

//app.MapGet("/", (IOptions<Personaldata> personal) => $"{personal.Value.FirstName} {personal.Value.LastName}");
app.MapGet("/", (Personaldata personal) => $"{personal.FirstName} {personal.LastName}");

app.Run();
