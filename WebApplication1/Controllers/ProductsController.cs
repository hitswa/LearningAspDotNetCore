using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Text.Json;
using WebApplication1.Modals;

namespace WebApplication1.Controllers
{
    // defining object, if not coming from modals
    // public class Person
    // {
    //     public int Id { get; set; }
    //     public string? FirstName { get; set; }
    //     public string? LastName { get; set; }
    //     public int Age { get; set; }
    // }

    [Controller]
    public class ProductsController : Controller
    {

        [HttpGet]
        // public string GetProductsAPI(HttpContext context)
        public IActionResult GetProductsAPI(HttpContext context)
        {
            // return "please provide productId";
            return Ok(@"please provide productId");
        }

        [HttpGet]
        // public ContentResult GetProductsAPITest(HttpContext context)
        public IActionResult GetProductsAPITest(HttpContext context)
        {
            // method one
            // return new ContentResult() {
            //     Content = "Hello World!",
            //     ContentType = "text/plane"
            // };

            // Shortcut provided by controller base class
            // returning plane text
            // return Content("Hello World!","text/plane");

            // return html content
            // return Content("<p>Hello World!</p>","text/html");

            // return JSON content
            return Content("{\"name\": \"Hitesh\"}","application/json; charset=utf-8");
        }

        [HttpGet]
        // public JsonResult GetProductsAPIJson(HttpContext context)
        public IActionResult GetProductsAPIJson(HttpContext context)
        {
            // Create a Person object with desired values
            // this can be either coming from a separate class declared above and commented or from modal class
            var person = new Person
            {
                Id = 123,
                FirstName = "John",
                LastName = "Doe",
                Age = 30
            };

            // Serialize the Person object to JSON
            // var jsonString = JsonSerializer.Serialize(person);

            // Return the JSON data as a JsonResult
            // return new JsonResult(jsonString);

            // shortcut from controller base class
            return Json(person);
        }

        [HttpGet]
        // public VirtualFileResult GetProductsAPIVirtualFile(HttpContext context)
        public IActionResult GetProductsAPIVirtualFile(HttpContext context)
        {
            // return any file which is available in wwwroot folder
            // return File("/docs/sample.txt", "text/plane");
            return new VirtualFileResult("/docs/sample.txt", "text/plane");
        }

        [HttpGet]
        // public PhysicalFileResult GetProductsAPIPhysicalFile(HttpContext context)
        public IActionResult GetProductsAPIPhysicalFile(HttpContext context)
        {
            // return any file which is available outside the wwwroot folder
            // return PhysicalFile("/static/sample.txt","text/plane");
            return new PhysicalFileResult("/static/sample.txt","text/plane");
        }

        [HttpGet]
        // public FileContentResult GetProductsAPIFile(HttpContext context)
        public IActionResult GetProductsAPIFile(HttpContext context)
        {
            // full path of the file
            string filePath = @"/Users/hitesh/Workspace/learning/AspDotNet/MyFirstAspProject/WebApplication1/static/sample.txt";

            // Read the file content into a byte array
            byte[] fileBytes = System.IO.File.ReadAllBytes(filePath);

            // return File(fileBytes,"text/plane");
            return new FileContentResult(fileBytes,"text/plane");
        }

        public IActionResult GetProductsStatus(HttpContext context) {
            // Response.StatusCode = 200;
            // Response.StatusCode = Convert.ToInt32(HttpStatusCode.OK);
            
            // return Unauthorized();
            // return new UnauthorizedResult();
            // return BadRequest();
            // return new BadRequestResult();
            // return NotFound();
            // return new NotFoundResult();

            return Ok("Checkout status codes");
        }

        internal static RequestDelegate GetProductsAPI(object context)
        {
            throw new NotImplementedException();
        }
    }
}
