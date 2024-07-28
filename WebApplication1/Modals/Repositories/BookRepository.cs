using System.Security.Cryptography.X509Certificates;
using WebApplication1.Modals;
using WebApplication1;
using Microsoft.EntityFrameworkCore;

namespace WebApplication1;

public class BookRepository
{
    private readonly ApplicationDbContext _dbContext;

    public BookRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Boolean> BookExists(int id) {
        return await _dbContext.Books.AnyAsync(x => x.Id == id);
    }

    public async Task<Book?> GetBookById(int id) {
        return await _dbContext.Books.FindAsync(id);
    }

    public async Task<List<Book>> GetAllBooks() {
        return await _dbContext.Books.ToListAsync();
    }

    public async Task AddBook(Book book) {
        await _dbContext.Books.AddAsync(new Book { Id = book.Id, Name = book.Name, Author = book.Author });
    }

    public async Task UpdateBook(Book book)
    {
        await _dbContext.Books
                            .Where(b => b.Id == book.Id)
                            .ExecuteUpdateAsync(b =>
                                b
                                    .SetProperty(p => p.Author, book.Author)
                                    .SetProperty(p => p.Name, book.Name)
                            );
    }

    public async Task RemoveBookById(int id)
    {
        await _dbContext.Books.Where(b => b.Id == id).ExecuteDeleteAsync();
    }


}
