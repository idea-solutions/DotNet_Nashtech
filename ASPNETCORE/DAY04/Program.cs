using DAY04.Middlewares;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.UseLogginMiddleware();

app.Run();
