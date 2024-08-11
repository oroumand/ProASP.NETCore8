using MinimalAPI.RoutParameter;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Hello World!");
app.MapGet("/Person/{id}", (int id) =>{
    var person = new PersonRepository().Get(id);

    return person;

});
//app.MapGet("/Person/2", () => {
//    var person = new PersonRepository().Get(2);
//    return person;

//});
//app.MapGet("/Person/3", () => {
//    var person = new PersonRepository().Get(3);
//    return person;

//});
//app.MapGet("/Person/4", () => {
//    var person = new PersonRepository().Get(4);
//    return person;

//});
app.Run();
