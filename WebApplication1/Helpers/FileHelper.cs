using System.IO;
using System.Threading.Tasks;
using System.Xml;

namespace WebApplication1.Helpers {
    public class FileHelper {

        public async Task SaveContentToFileAsync(string content)
        {
            string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "XmlFiles", "books.xml");
            Directory.CreateDirectory(Path.GetDirectoryName(filePath)); // Create directory if it doesn't exist

            await using (var writer = new StreamWriter(filePath, append: false))
            {
                await writer.WriteAsync(content);
            }
        }

        public async Task<string> ReadContentFromFileAsync(string filePath)
        {
            if (!File.Exists(filePath))
                throw new FileNotFoundException($"File not found: {filePath}");

            using (var reader = new StreamReader(filePath))
            {
                return await reader.ReadToEndAsync();
            }
        }
    }
}