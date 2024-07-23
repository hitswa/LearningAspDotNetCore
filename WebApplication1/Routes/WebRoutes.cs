namespace WebApplication1.Routes
{
    public static class WebRoutes
    {
        public static void MapRoutes(IEndpointRouteBuilder endpoints)
        {
            endpoints.MapGet("/products", () => "Web response from product path");
            // Add other web routes here
        }
    }
}
