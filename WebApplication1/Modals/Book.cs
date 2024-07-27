using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Modals
{
    public class Book
    {
        internal int id;

        [Required]
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Author { get; set; }


        public ICollection<Book> Books { get; set; }
    }
}