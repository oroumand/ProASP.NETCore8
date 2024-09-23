using Microsoft.AspNetCore.RateLimiting;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRateLimiter(opts =>
{
    opts.AddFixedWindowLimiter("fixedWindow",
        fixOpts =>
        {
            fixOpts.PermitLimit = 1;
            fixOpts.QueueLimit = 0;
            fixOpts.Window = TimeSpan.FromSeconds(15);
        });
});

var app = builder.Build();

app.UseRateLimiter();

app.MapGet("/", () => "Hello World!").RequireRateLimiting("fixedWindow");


app.Run();
