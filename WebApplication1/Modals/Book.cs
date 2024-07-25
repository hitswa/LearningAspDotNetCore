using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Modals
{
    public class Book
    {
        [Required]
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Author { get; set; }
    }
}