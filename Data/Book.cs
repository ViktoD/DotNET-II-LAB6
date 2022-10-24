using System.ComponentModel.DataAnnotations;

namespace lab6.Data
{
    public class Book
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public string Name { get; set; } = null!;
        [Required]
        public string Author { get; set; } = null!;
        public int Price { get; set; }
        public int YearPublished { get; set; }
    }
}
