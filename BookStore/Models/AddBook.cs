namespace BookStore.Models
{
    public class AddBook
    {
        public string Title { get; set; }
        public string FirstNameOfAuthor { get; set; }
        public string LastNameOfAuthor { get; set; }
        public string Species { get; set; }
        public int NumberOfPages { get; set; }

        public DateTime PublicationDate { get; set; }
    }
}
