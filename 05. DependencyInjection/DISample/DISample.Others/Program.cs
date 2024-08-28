using DISample.Others.Chain;
using DISample.Others.NotificationService;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddScoped<FirstDependency>();
builder.Services.AddScoped<SeccondDependency>();
builder.Services.AddScoped<ThirdDependency>();
builder.Services.AddTransient<INotificaton, SmsNotification>();
builder.Services.AddTransient<INotificaton, EmailNotification>();
builder.Services.AddKeyedTransient<INotificaton, EmailNotification>("email");
builder.Services.AddKeyedTransient<INotificaton, SmsNotification>("sms");
builder.Services.AddTransient(typeof(ICollection<>), typeof(List<>));

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.MapGet("/dep", async (HttpContext context, ThirdDependency third) =>
{

});

app.MapGet("/unbound", async (HttpContext context) =>
{
    ICollection<string> list = context.RequestServices.GetRequiredService<ICollection<string>>();
    ICollection<int> listint = context.RequestServices.GetRequiredService<ICollection<int>>();
});

app.Run();
