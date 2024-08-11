using MinimalAPI.RoutGroupSamples;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Hello World!");
var routGroupPeople = app.MapGroup("/people");
var people2 = routGroupPeople.MapGroup("/temp");
routGroupPeople.MapGet("", PersonApplicaitonService.GetAll);
routGroupPeople.MapGet("/{id}", PersonApplicaitonService.Get);
routGroupPeople.MapPost("", PersonApplicaitonService.Add);
routGroupPeople.MapDelete("{id}", PersonApplicaitonService.Remove);


app.Run();
