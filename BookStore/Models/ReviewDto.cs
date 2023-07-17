using BookStore.Data;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookStore.Models
{
    public class ReviewDto
    {
        [Required]
        public string Content { get; set; }

    }
}
