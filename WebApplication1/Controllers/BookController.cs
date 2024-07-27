using Microsoft.AspNetCore.Mvc;
using WebApplication1.Modals;

namespace WebApplication1.Controllers
{
    [Controller]
    [Route("api/v1/")]
    public class BookController : Controller
    {

        [HttpGet]
        [Route("books")]
        public IActionResult GetAllBooks() {
            return Json(BookRepository.GetAllBooks());
        }

        [HttpGet]
        [Route("book/{bookId:int}")]
        public IActionResult GetBookById([FromRoute] int bookId) {
            if(bookId < 1) return BadRequest();

            var book = BookRepository.GetBookById(bookId);

            if( book == null ) return NotFound();

            return Ok(book);
        }

        [HttpPost]
        [Route("book")]
        public IActionResult AddBook([FromBody] Book book) {
            return Json(BookRepository.AddBook(book));
        }

        [HttpPut]
        [Route("book/{bookId:int}")]
        public IActionResult UpdateBookById([FromRoute] int bookId, [FromBody]Book book) {
            
            if( !BookRepository.BookExists(bookId) )
                return BadRequest();

            return Json(BookRepository.UpdateBook(book));
        }

        [HttpDelete]
        [Route("book/{bookId:int}")]
        public IActionResult DeleteBookById([FromRoute] int bookId) {
            return Json(BookRepository.RemoveBookById(bookId));
        }
    }
}
