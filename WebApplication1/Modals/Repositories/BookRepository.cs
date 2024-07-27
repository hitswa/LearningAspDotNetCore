using System.Security.Cryptography.X509Certificates;
using WebApplication1.Modals;

namespace WebApplication1;

public static class BookRepository
{
    private static List<Book> books = new List<Book>([
        new Book{ Id = 1, Name = "", Author = "" },
        new Book{ Id = 2, Name = "", Author = "" },
        new Book{ Id = 3, Name = "", Author = "" },
    ]);

    public static Boolean BookExists(int id) {
        return books.Exists(x => x.Id == id);
    }

    public static Book? GetBookById(int id) {
        return books.Find(x => x.Id == id);
    }

    public static List<Book> GetAllBooks() {
        return books.ToList();
    }

    public static List<Book> AddBook(Book book) {
        books.Add(new Book{ Id = book.Id, Name= book.Name, Author = book.Author });
        return books.ToList();
    }

    public static List<Book> UpdateBook(Book book) {
        var obj = books.Find(x => x.Id == book.id);
        
        if(obj != null) {
            obj.Author = book.Author;
            obj.Name = book.Name;
        }

        return books.ToList();
    }

    public static List<Book> RemoveBookById(int id) {
        books.Remove(new Book() { Id  = id });
        return books.ToList();
    }

    
}
