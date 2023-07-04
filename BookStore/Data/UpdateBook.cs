namespace BookStore.Data
{
    public class UpdateBook
    {
        public string Title { get; set; }
        public string FirstNameOfAuthor { get; set; }
        public string LastNameOfAuthor { get; set; }
        public string Species { get; set; }
        public int NumberOfPages { get; set; }

        public DateTime PublicationDate { get; set; }
    }
}
