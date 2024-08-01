var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
//app.UseWelcomePage("/");
app.UseStaticFiles();
app.UseRouting();
app.MapGet("/", () =>
{
    throw new Exception();
});

app.Run();
