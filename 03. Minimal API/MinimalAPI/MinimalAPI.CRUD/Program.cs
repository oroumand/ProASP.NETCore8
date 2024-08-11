using Microsoft.AspNetCore.Builder;
using MinimalAPI.CRUD;
using System.Diagnostics.CodeAnalysis;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Hello World!");
app.MapGet("/people", () =>
{
    return PersonRepository.Instance().Get();
});

var GetById = (int id) =>
{
    return PersonRepository.Instance().Get(id);
};


app.MapGet("/people/{id}", GetById);

app.MapPost("/people", PersonApplicaitonService.Add);

var hanlder = new PersonApplicaitonService();
app.MapDelete("/People/{id}", hanlder.Remove);
app.Run();
