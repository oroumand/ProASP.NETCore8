using Logging.SeriLogSample;
using Serilog;

Log.Logger = new LoggerConfiguration()
    .WriteTo.Console()
    .CreateLogger();

try
{
    Log.Information("Starting web application");

    var builder = WebApplication.CreateBuilder(args);
    builder.Services.AddSerilog(); // <-- Add this line
    builder.Services.AddScoped<SampleDB>();

    var app = builder.Build();
    app.MapGet("/", (SampleDB db) =>
    {
        db.Add(123);
        return "Hello World!";
    });

    app.Run();
}
catch (Exception ex)
{
    Log.Fatal(ex, "Application terminated unexpectedly");
}
finally
{
    Log.CloseAndFlush();
}