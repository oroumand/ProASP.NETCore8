var builder = WebApplication.CreateBuilder(args);
//builder.Services.AddHttpsRedirection(opts => {
//    opts.RedirectStatusCode = StatusCodes.Status303SeeOther;
//    opts.HttpsPort = 443;
//});
builder.Services.AddHsts(opts => {
    opts.MaxAge = TimeSpan.FromDays(1);
    opts.IncludeSubDomains = true;
});


var app = builder.Build();
app.UseHsts();
app.UseHttpsRedirection();




app.MapGet("/", () => "Hello World!");

app.Run();
