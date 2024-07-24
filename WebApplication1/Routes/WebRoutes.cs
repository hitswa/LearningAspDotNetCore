namespace WebApplication1.Routes
{
    public static class WebRoutes
    {
        public static void MapRoutes(IEndpointRouteBuilder endpoints)
        {
            endpoints.Map("/products", async(context) => {
                await context.Response.WriteAsync("WEB response from product path");
            });
            // Add other web routes here

            // endpoints.MapControllers();
        }
    }
}
