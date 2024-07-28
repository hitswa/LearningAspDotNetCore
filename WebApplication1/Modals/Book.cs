using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Modals
{
    public class Book
    {
        [Key, Required]
        public int Id { get; set; }
        public string? Name { get; set; } = string.Empty;
        public string? Author { get; set; } = string.Empty;
    }
}