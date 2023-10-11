using System.ComponentModel.DataAnnotations;

namespace Domain
{
    public class Author
    {
        [Required]
        [Key]
        public int Id { get; set; }
        [MaxLength(250)]
        public string Name { get; set; }
        public List<Book> Books { get; set; }
    }
}