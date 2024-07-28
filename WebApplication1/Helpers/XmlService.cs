using System.IO;
using System.Xml.Serialization;
using WebApplication1.Modals;

namespace WebApplication1.Helpers
{
    public class XmlHelper
    {
        public async Task<string> CreateXmlFromBooksAsync(List<Book> books)
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

        public async Task<List<Book>> ReadBooksFromXmlAsync(string filePath)
        {
            if (!File.Exists(filePath))
                throw new FileNotFoundException($"File not found: {filePath}");

            using (var reader = new StreamReader(filePath))
            {
                var serializer = new XmlSerializer(typeof(library));
                var library = (library)serializer.Deserialize(reader);
                return library.book.Select(b => new Book
                {
                    Id = (int)b.id,
                    Name = (string?)b.name,
                    Author = (string?)b.author
                }).ToList();
            }
        }
    }

}
