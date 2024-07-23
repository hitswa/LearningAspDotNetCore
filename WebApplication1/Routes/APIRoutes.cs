
namespace WebApplication1.Routes
{
    public static class ApiRoutes
    {
        public static void MapRoutes(IEndpointRouteBuilder endpoints)
        {
            endpoints.MapGet("/api/v1/products", () => "API response from product path");
            // Add other API routes here
        }
    }
}
