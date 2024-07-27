using Microsoft.EntityFrameworkCore;
using WebApplication1.Modals;

namespace WebApplication1;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) {

    }

    public DbSet<Book> Books { get; set; }
}
