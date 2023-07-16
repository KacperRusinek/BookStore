using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BookStore.Data
{
    public class Review
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Content { get; set; } //tresc opinii
        [ForeignKey("BookId")]
        public int BookId { get; set; }
        public CreateBook Book { get; set; }
    }
}
