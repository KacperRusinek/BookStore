using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookStore.Data
{
    public class CreateBook
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public string FirstNameOfAuthor { get; set; }
        public string LastNameOfAuthor { get; set; }
        public string Species { get; set; }
        public int NumberOfPages { get; set; }
        public int Rating { get; set; }
        public DateTime PublicationDate { get; set; }
        public ICollection<Review> Reviews { get; set; }

    } 
}
