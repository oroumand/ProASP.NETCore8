using DISample.InroToDI;
using DISample.InroToDI.Services;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddTransient<IResponseFormatter,SimpleResponseFormatter>();
//builder.Services.AddScoped<IResponseFormatter, SimpleResponseFormatter>();
//builder.Services.AddSingleton<JsonResponseFormatter>();

var app = builder.Build();
app.UseNamePrinter();

//app.MapGet("/print/ce", MyEndpoint.NamePrinter);



app.MapGet("/print/func", async (HttpContext context,IResponseFormatter responseFormatter, IResponseFormatter responseFormatter2) =>
{   
    await responseFormatter.Write(context, "Alireza Oroumand From function Endpoint");
    await responseFormatter2.Write(context, "Alireza Oroumand2 From function Endpoint");
});
app.MapGet("/", () => "Hello World!");

app.Run();
