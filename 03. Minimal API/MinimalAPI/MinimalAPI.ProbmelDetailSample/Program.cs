using MinimalAPI.ProbmelDetailSample;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Hello World!");
app.MapGet("/people", PersonApplicaitonService.GetAll);
app.MapGet("/people/{id}", PersonApplicaitonService.Get);
app.MapPost("/people", PersonApplicaitonService.Add);
app.MapDelete("/people/{id}", PersonApplicaitonService.Remove);


app.Run();
