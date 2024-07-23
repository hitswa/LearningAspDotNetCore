using WebApplication1.Routes;

var builder = WebApplication.CreateBuilder(args);

var app = builder.Build();

// Adding routes support to application
app.UseRouting();

app.UseEndpoints(endpoints =>
{
    ApiRoutes.MapRoutes(endpoints); // API Routes
    WebRoutes.MapRoutes(endpoints); // Web Routes
});

app.MapGet("/", () => "Hello World!");

app.Run();
