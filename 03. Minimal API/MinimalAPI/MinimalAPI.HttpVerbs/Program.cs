using Microsoft.AspNetCore.Http.HttpResults;
using MinimalAPI.HttpVerbs;
using MinimalAPI.RoutParameter;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Hello World!");
//app.MapGet("/People", () =>
//{
//    var people = PersonRepository.Instance.Get();
//    return people;
//});
app.MapGet("/People/{Id}", (int id) =>
{
    var person = PersonRepository.Instance.Get(id);
    return person;
});
app.MapPost("/People", () =>
{
    Person newPerson = new Person
    {
        Id = 5,
        FirstName = "Foo",
        LastName = "Bar",
    }
    ;
    return newPerson;
});
app.Run();
