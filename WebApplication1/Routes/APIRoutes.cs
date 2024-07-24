using Microsoft.Extensions.ObjectPool;
using WebApplication1.Controllers;

namespace WebApplication1.Routes
{

    public static class ApiRoutes
    {
        public static void MapRoutes(IEndpointRouteBuilder endpoints)
        {

            // Route: <route>/{<variable>:<constrain>?} <= ? for optional parameter
            // <route> : can be any URL
            // <variable> : can be any variable in which value will be received
            // <constrain> : to restrict type 
            // (int|bool|datetime|decimal|long|guid|minlength(value)|maxlength(value)|length(min,max)|range(min,max)|alpha|regex(expression))
            // you can also write custom routes
            // endpoints.Map("/api/v1/products/{productId:int?}", async(context) => {
            //     if( context.Request.RouteValues.ContainsKey("productId") ) {
            //         int? productId = Convert.ToInt32(context.Request.RouteValues["productId"]);
            //         await context.Response.WriteAsync($@"API response from product path {productId}");
            //     } else {
            //         await context.Response.WriteAsync("please provide productId");
            //     }
            // });
            // Add other API routes here

            endpoints.MapGet("api/v1/products", ProductsController.GetProductsAPI);

            // endpoints.MapControllers();
        }
    }
}
