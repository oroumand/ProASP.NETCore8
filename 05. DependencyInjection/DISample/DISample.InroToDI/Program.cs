using DISample.InroToDI;
using DISample.InroToDI.Services;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSingleton<IResponseFormatter,SimpleResponseFormatter>();
builder.Services.AddSingleton<JsonResponseFormatter>();

var app = builder.Build();
app.UseNamePrinter();

app.MapGet("/print/ce", MyEndpoint.NamePrinter);



app.MapGet("/print/func", async (HttpContext context,IResponseFormatter responseFormatter) =>
{
    await responseFormatter.Write(context, "Alireza Oroumand From function Endpoint");
});
app.MapGet("/", () => "Hello World!");

app.Run();
