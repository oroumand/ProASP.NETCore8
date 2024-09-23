var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
else
{
    app.UseExceptionHandler("/exception");
}

app.MapGet("/", () =>
{
    throw new Exception();
});
app.MapGet("/exception", () => "Exception");

app.Run();
