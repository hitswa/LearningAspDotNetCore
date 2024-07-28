using System.Xml.Serialization;
using WebApplication1.Modals;

namespace WebApplication1.Services
{
    public class XmlService
    {
        public async Task<string> CreateXmlFromBooks(List<Book> books)
        {
            var library = new library();
            library.book = books.Select(b => new libraryBook
            {
                id = b.Id,
                name = b.Name,
                author = b.Author
            }).ToArray();

            var serializer = new XmlSerializer(typeof(library));
            using (var writer = new StringWriter())
            {
                serializer.Serialize(writer, library);
                return writer.ToString();
            }
        }
    }
}
