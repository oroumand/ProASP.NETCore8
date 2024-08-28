using DISample.Inroduction;
using DISample.Inroduction.Services;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();
app.UseNamePrinter();

app.MapGet("/print/ce", MyEndpoint.NamePrinter);

IResponseFormatter responseFormatter = ResponseWriterTypeBroker.Get();

app.MapGet("/print/func", async context =>
{
    await responseFormatter.Write(context, "Alireza Oroumand From function Endpoint");
});
app.MapGet("/", () => "Hello World!");

app.Run();
