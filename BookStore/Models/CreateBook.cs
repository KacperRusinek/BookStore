namespace BookStore.Models
{
    public class CreateBook
    {
        public string Title { get; set; }
        public string FirstNameOfAuthor  { get; set; }
        public string LastNameOfAuthor  { get; set; }
        public string Species  { get; set; }
        public int PublicationYear  { get; set; }
        public DateTime PublicationDate { get; set; } 
    }
}
