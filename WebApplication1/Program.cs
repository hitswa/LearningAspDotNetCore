using WebApplication1.Routes;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers(); // Add controllers for API routes
// Add other services if needed

var app = builder.Build();

// enabling static file content routes
app.UseStaticFiles();

// Adding routes support to application
app.UseRouting();

// app.Use(async (context, next) => {
//     Microsoft.AspNetCore.Http.Endpoint endpoint = context.GetEndpoint();
//     if(endpoint != null) {
//         await context.Response.WriteAsync($@"Route: {endpoint.DisplayName} ");
//     }
//     await next(context);
// });


app.UseEndpoints(endpoints =>
{
    endpoints.Map("/xyz", async (context)=>{
        await context.Response.WriteAsync("Hello World");
    });

    endpoints.Map("/xyz/{abc}", async (context) => {
        string? abc = Convert.ToString(context.Request.RouteValues["abc"]);
        await context.Response.WriteAsync($@"You passed {abc} as URL Parameter");
    });

    ApiRoutes.MapRoutes(endpoints); // API Routes
    WebRoutes.MapRoutes(endpoints); // Web Routes
});

app.MapGet("/", () => "Welcome to the ASP.NET Core 8.0 Project");

// Default route: this will execute if no other route match
app.Run(async context => {
    await context.Response.WriteAsync($"404 Not Found!\nRequest received at: {context.Request.Path}");
});

app.Run();
