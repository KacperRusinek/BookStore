using BookStore.Data;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookStore.Models
{
    public class ReviewDto
    {
        //public int Id { get; set; }
        [Required]
        public string Content { get; set; } //tresc opinii
        //[ForeignKey("BookId")]
        //public int BookId { get; set; }
    }
}
