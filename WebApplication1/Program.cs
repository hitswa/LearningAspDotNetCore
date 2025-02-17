using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using WebApplication1;
using WebApplication1.Modals;
using WebApplication1.Modals.Reposotries;

var builder = WebApplication.CreateBuilder(args);

// Register all the controllers as service
builder.Services.AddControllers();

// Register ApplicationDbContext
builder.Services.AddDbContext<ApplicationDbContext>(options => {
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"));
});

// Register services
builder.Services.AddScoped<BookRepository>();
builder.Services.AddScoped<libraryBook>();

var app = builder.Build();

// enabling static file content routes
app.UseStaticFiles();

// enable routing and endpoint support to application
app.UseRouting();

app.UseEndpoints(endpoints => {
    endpoints.MapControllers();
});

// app.MapControllers();

app.MapGet("/", () => "Welcome to the ASP.NET Core 8.0 Project");

// Default route: this will execute if no other route match
app.Run(async context => {
    await context.Response.WriteAsync($"404 Not Found!\nRequest received at: [{context.Request.Method}] {context.Request.Path}");
});

app.Run();
