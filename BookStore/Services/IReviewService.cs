using BookStore.Models;
using BookStore.Data;

namespace BookStore.Services
{
    public interface IReviewService
    {
        public int AddReviewByTitle(string title, ReviewDto dto);
        public IEnumerable<ReviewDto> GetReviewsByBookTitle(string bookTitle);
        public ReviewDto UpdateReview(int reviewId, ReviewDto reviewDto);
        bool DeleteReview(int reviewId);
    }
}
