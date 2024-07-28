using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Modals;
using WebApplication1.Modals.Reposotries;
using WebApplication1.Services;

namespace WebApplication1.Controllers
{
    [Controller]
    [Route("/api/v1/xml")]
    public class LibraryController: Controller
    {
        private readonly libraryBook _libraryBook;
        private readonly BookRepository _bookRepository;

        public LibraryController(libraryBook lb, BookRepository bookRepository)
        {
            _libraryBook = lb;
            _bookRepository = bookRepository;
        }

        [HttpGet]
        [Route("library")]
        public async Task<IActionResult> GetAllBooks()
        {
            var books = await _bookRepository.GetAllBooks();
            XmlService xmlService = new XmlService();
            var xml = await xmlService.CreateXmlFromBooks(books);
            return Content(xml, "text/xml");
        }

    }
}
