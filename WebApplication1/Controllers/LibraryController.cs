using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Modals;
using WebApplication1.Modals.Reposotries;
using WebApplication1;
using WebApplication1.Helpers;

namespace WebApplication1.Controllers
{
    [Controller]
    [Route("/api/v1/xml")]
    public class LibraryController: Controller
    {
        private readonly libraryBook _libraryBook;
        private readonly BookRepository _bookRepository;

        private readonly FtpHelper _ftpHelper;
        private readonly FileHelper _fileHelper;
        private readonly IConfiguration _configuration;

        public LibraryController(libraryBook lb, BookRepository bookRepository, FtpHelper ftpHelper, FileHelper fileHelper, IConfiguration configuration)
        {
            _libraryBook = lb;
            _bookRepository = bookRepository;

            _ftpHelper = ftpHelper;
            _fileHelper = fileHelper;
            _configuration = configuration;
        }

        [HttpGet]
        [Route("library")]
        public async Task<IActionResult> GetAllBooks()
        {
            // Get all books from database
            var books = await _bookRepository.GetAllBooks();

            // create xml file from data
            XmlHelper xmlHelper = new XmlHelper();
            var xml = await xmlHelper.CreateXmlFromBooksAsync(books);

            // save xml file to folder
            FileHelper fileHelper = new FileHelper();
            await fileHelper.SaveContentToFileAsync(xml);

            // return xml response to request
            return Content(xml, "text/xml");
        }

        [HttpGet]
        [Route("libraryFromFile")]
        public async Task<IActionResult> GetAllBooksFromFile()
        {
            string xmlFilePath = "path/to/your/xml/file"; // Replace with actual path

            // read xml file
            FileHelper fileHelper = new FileHelper();
            string xmlContent = await fileHelper.ReadContentFromFileAsync(xmlFilePath);

            // Generate a temporary file to store the XML content
            string tempFilePath = Path.GetTempFileName();
            await fileHelper.SaveContentToFileAsync(xmlContent);

            // Upload the temporary file to FTP
            string ftpDestination = "/path/to/ftp/destination/file.xml"; // Replace with actual FTP path
            FtpHelper ftpHelper = new FtpHelper(_configuration);
            await ftpHelper.UploadFileAsync(tempFilePath, ftpDestination);

            // return xml response to request
            return Content(xmlContent, "text/xml");
        }

    }
}
