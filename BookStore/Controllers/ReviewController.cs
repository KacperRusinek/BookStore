using BookStore.Data;
using BookStore.Models;
using BookStore.Services;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Controllers
{
    [ApiController]
    [Route("api/review")]
    public class ReviewController : Controller
    {
        private readonly IReviewService _reviewService;
        private readonly BookStoreDbContext _bookStoreDbContext;
        public ReviewController(IReviewService reviewService, BookStoreDbContext dbContext)
        {
            _reviewService = reviewService;
            _bookStoreDbContext = dbContext;
        }

        [HttpPost]
        public IActionResult AddReview([FromBody] ReviewDto dto)
        {
            var review = _reviewService.CreateReview(dto);
            return Created($"{review}", null);

        }
        
    }
}
