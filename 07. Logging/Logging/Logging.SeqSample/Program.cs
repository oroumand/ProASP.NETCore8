using Logging.SeqSample;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddScoped<SampleDB>();
builder.Logging.AddSeq();
var app = builder.Build();


app.MapGet("/", (SampleDB db) =>
{

    db.Add(123);
    return "Hello World!";
});

app.Run();
