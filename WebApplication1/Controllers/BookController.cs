using Microsoft.AspNetCore.Mvc;
using WebApplication1.Modals;

namespace WebApplication1.Controllers
{
    [Controller]
    public class BookController : Controller
    {
        private List<Book> books = new List<Book>([
            new Book{ Id = 1, Name = "", Author = "" },
            new Book{ Id = 2, Name = "", Author = "" },
            new Book{ Id = 3, Name = "", Author = "" },
        ]);

        [HttpGet]
        [Route("/api/v1/books")]
        public IActionResult GetAllBooks() {
            return Json(this.books);
        }

        [HttpGet]
        [Route("/api/v1/book/{bookId:int}")]
        public IActionResult GetBookById([FromRoute] int bookId) {
            var book = this.books.FirstOrDefault(book => book.Id == bookId);
            if( book == null ) {
                return Content("Not found");
            }
            return Json(book);
        }

        [HttpPost]
        [Route("/api/v1/book")]
        public IActionResult AddBook([FromBody] Book book) {
            this.books.Add(new Book() { Id = (books.Count + 1), Author = book.Author, Name = book.Name });
            return Json(this.books);
        }

        [HttpPut]
        [Route("/api/v1/book/{bookId:int}")]
        public IActionResult UpdateBookById([FromRoute] int bookId, [FromBody]Book book) {
            var bookSubjectedToBeUpdated = this.books.FirstOrDefault(book => book.Id == bookId);
            
            if( bookSubjectedToBeUpdated == null ) {
                return Content("Not found");
            }

            bookSubjectedToBeUpdated.Id = book.Id;
            bookSubjectedToBeUpdated.Author = book.Author;
            bookSubjectedToBeUpdated.Name = book.Name;

            return Json(books);
        }

        [HttpDelete]
        [Route("/api/v1/book/{bookId:int}")]
        public IActionResult DeleteBookById([FromRoute] int bookId) {
            var books = new List<Book>([
                new Book{ Id  = 1, Name = "The Secret", Author = "Rhonda Beyonce" },
                new Book{ Id  = 2, Name = "Hello", Author = "Hitesh" },
            ]);
            books.Remove(new Book() { Id  = 1, Name = "The Secret", Author = "Rhonda Beyonce" });
            return Json(books);
        }
    }
}
