var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Hello World!");
app.MapGet("/Capital/{CountryName}", async (context) =>
{

    string country = context.Request.RouteValues["CountryName"].ToString();
    string capital = string.Empty;
    switch (country)
    {
        case "Iran":
            capital = "Tehran";
            break;
        case "USA":
            capital = "Washengton";
            break;
        case "Tehran":
            var linkGenerator = context.RequestServices.GetService<LinkGenerator>();
            string path = linkGenerator.GetPathByRouteValues(context, "Population", new
            {
                CityName = "Tehran"
            });

            context.Response.Redirect(path);
            return;
    }

    if (!string.IsNullOrEmpty(capital))
    {
        await context.Response.WriteAsync(capital);
    }
    else
    {
        context.Response.StatusCode = 404;
    }

});
app.MapGet("/Population/{CityName}", async (context) =>
{


    string city = context.Request.RouteValues["CityName"].ToString();
    string population = string.Empty;

    switch (city)
    {
        case "Tehran":
            population = "10000000";
            break;
        case "Isfahan":
            population = "5000000";
            break;

    }

    if (!string.IsNullOrEmpty(population))
    {
        await context.Response.WriteAsync(population);
    }
    else
    {
        context.Response.StatusCode = 404;
    }


}).WithMetadata(new RouteNameMetadata("Population"));

app.Run();
