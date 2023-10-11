using System.ComponentModel.DataAnnotations;

namespace Domain
{
    public class Book
    {
        [Required]
        [Key]
        public int Id { get; set; }
        [MaxLength(250)]
        public string Title { get; set; }
        [MaxLength(250)]
        public string ISBN { get; set; }
        public Author Author { get; set; }
        public bool CheckedOut { get; set; }
    }
}