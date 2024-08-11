using MinimalAPI.Filters;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Hello World!").AddEndpointFilter(async (context, next) =>
{

    app.Logger.LogInformation("ARO: Start Executing My Endpoint");
    var result = await next(context);
    app.Logger.LogInformation("ARO: End Executing My Endpoint");

    return result;
}).AddEndpointFilter<MyFilter>();

app.Run();
