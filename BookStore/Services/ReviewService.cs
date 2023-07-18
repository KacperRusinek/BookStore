using AutoMapper;
using BookStore.Data;
using BookStore.Interfaces;
using BookStore.Models;

namespace BookStore.Services
{
    public class ReviewService : IReviewService
    {
        private readonly IMapper _mapper;
        private readonly ILogger<BookStoreService> _logger;
        private readonly BookStoreDbContext _dbContext;
        public ReviewService(BookStoreDbContext bookStoreDbContext, IMapper mapper)
        {
            _dbContext = bookStoreDbContext;
            _mapper = mapper;
        }
        public int AddReviewByTitle(string title, ReviewDto dto)
        {
            var book = _dbContext.Books.FirstOrDefault(b => b.Title == title);

            if (book != null)
            {
                var review = _mapper.Map<Review>(dto);
                review.Book = book;
                _dbContext.Reviews.Add(review);
                _dbContext.SaveChanges();
                return review.Id;
            }
            return 0;
        }
        public IEnumerable<ReviewDto> GetReviewsByBookTitle(string bookTitle)
        {
            var book = _dbContext.Books.FirstOrDefault(b => b.Title == bookTitle);

            if (book == null)
            {
                return null; 
            }

            var reviews = _dbContext.Reviews
                .Where(r => r.Book.Title == bookTitle)
                .ToList();

            return _mapper.Map<IEnumerable<ReviewDto>>(reviews);
        }
        public ReviewDto UpdateReview(int reviewId, ReviewDto reviewDto)
        {
            var existingReview = _dbContext.Reviews.FirstOrDefault(r => r.Id == reviewId);
            if (existingReview == null)
            {
                return null;
            }

            existingReview.Content = reviewDto.Content;
            _dbContext.SaveChanges();

            return _mapper.Map<ReviewDto>(existingReview);
        }
        public bool DeleteReview(int reviewId)
        {
            var existingReview = _dbContext.Reviews.FirstOrDefault(r => r.Id == reviewId);
            if (existingReview == null)
            {
                return false;
            }

            _dbContext.Reviews.Remove(existingReview);
            _dbContext.SaveChanges();

            return true;
        }
    }
}
