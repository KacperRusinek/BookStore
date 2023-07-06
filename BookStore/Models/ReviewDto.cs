using System.ComponentModel.DataAnnotations;

namespace BookStore.Models
{
    public class ReviewDto
    {
        public string Content { get; set; }
        [Range(1, 10)]
        public int rating { get; set; }
        public string TitleOfBook { get; set; }
    }
}
