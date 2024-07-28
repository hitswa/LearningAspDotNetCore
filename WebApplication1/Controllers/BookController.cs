using Microsoft.AspNetCore.Mvc;
using WebApplication1.Modals;
using WebApplication1.Modals.Reposotries;

namespace WebApplication1.Controllers
{
    [Controller]
    [Route("api/v1/")]
    public class BookController : Controller
    {
        private readonly BookRepository _bookRepository;

        public BookController(BookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        [HttpGet]
        [Route("books")]
        public async Task<IActionResult> GetAllBooks()
        {
            var books = await _bookRepository.GetAllBooks();
            return Ok(books);
        }

        [HttpGet]
        [Route("book/{bookId:int}")]
        public async Task<IActionResult> GetBookById([FromRoute] int bookId)
        {
            if (bookId < 1) return BadRequest();

            var book = await _bookRepository.GetBookById(bookId);

            if (book == null) return NotFound();

            return Ok(book);
        }

        [HttpPost]
        [Route("book")]
        public async Task<IActionResult> AddBook([FromBody] Book book)
        {
            return Ok(_bookRepository.AddBook(book));
        }

        [HttpPut]
        [Route("book/{bookId:int}")]
        public async Task<IActionResult> UpdateBookById([FromRoute] int bookId, [FromBody] Book book)
        {
            return Ok(_bookRepository.UpdateBook(book));
        }

        [HttpDelete]
        [Route("book/{bookId:int}")]
        public async Task<IActionResult> DeleteBookById([FromRoute] int bookId)
        {
            return Ok(_bookRepository.RemoveBookById(bookId));
        }
    }
}
