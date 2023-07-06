using System.ComponentModel.DataAnnotations;

namespace BookStore.Data
{
    public class Review
    {
        [Key]
        public int Id { get; set; }
        public string Content { get; set; }
        [Range(1,10)]
        public int rating { get; set; }
        public string TitleOfBook { get; set; }
        public int BookId { get; set; } //klucz obcy
        public CreateBook Book { get; set; } //nawigacyjne pole - ksiażki dla danej opinii
  

    }
}
