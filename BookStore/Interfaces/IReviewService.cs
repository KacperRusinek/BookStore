using BookStore.Models;
using BookStore.Data;

namespace BookStore.Interfaces
{
    public interface IReviewService
    {
        public int AddReviewByTitle(string title, ReviewDto dto);
        public IEnumerable<ReviewDto> GetReviewsByBookTitle(string bookTitle);
        public ReviewDto UpdateReview(int reviewId, ReviewDto reviewDto);
        public bool DeleteReview(int reviewId);
    }
}
