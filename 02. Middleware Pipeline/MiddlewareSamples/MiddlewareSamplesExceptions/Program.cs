var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();
//if(app.Environment.IsDevelopment())
//{
//    app.UseDeveloperExceptionPage();

//}
//else
//{
//    app.UseExceptionHandler();
//}
app.UseExceptionHandler("/error");

app.MapGet("/error", () =>
{
    throw new NullReferenceException();
});
app.MapGet("/", () =>
{
    throw new Exception();
});

app.Run();
