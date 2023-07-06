using AutoMapper;
using BookStore.Data;
using BookStore.Models;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Services
{
    public class ReviewService : IReviewService
    {
        private readonly IMapper _mapper;
        private readonly BookStoreDbContext _dbContext;
        public ReviewService(BookStoreDbContext bookStoreDbContext, IMapper mapper)
        {
            _dbContext = bookStoreDbContext;
            _mapper = mapper;
        }

        //public int CreateReview(ReviewDto dto)
        //{
        //    var review = _mapper.Map<Review>(dto);
        //    _dbContext.Reviews.Add(review);
        //    _dbContext.SaveChanges();

        //    return review.Id;
        //}
        public int CreateReview(int bookId, ReviewDto dto)
        {
            // Odnalezienie książki na podstawie bookId
            CreateBook book = _dbContext.Books.FirstOrDefault(b => b.Id == bookId);

            if (book != null)
            {
                // Tworzenie nowej recenzji i przypisanie odpowiednich wartości
                var review = _mapper.Map<Review>(dto);

                // Dodanie recenzji do kontekstu i zapisanie zmian
                _dbContext.Reviews.Add(review);
                _dbContext.SaveChanges();
                return review.Id;
            } else { return 0; }
            
        }


    }
}
