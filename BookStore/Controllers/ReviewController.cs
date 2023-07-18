using BookStore.Interfaces;
using BookStore.Models;
using BookStore.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Controllers
{
    [ApiController]
    [Route("api/Review")]
    public class ReviewController : ControllerBase
    {
        private readonly IReviewService _reviewService;
        public ReviewController(IReviewService reviewService, ILogger<BookStoreService> logger)
        {
            _reviewService = reviewService;
        }

        [HttpPost("AddReviewByTitle")]
        public ActionResult AddReviewByTitile([FromQuery] string title, [FromBody] ReviewDto dto)
        {
            var review = _reviewService.AddReviewByTitle(title, dto);

            if (review != 0)
            {
                return Created($"/api/restaurant/{review}", review);
            }

            return BadRequest("Książka o podanym tytule nie została znaleziona."); // lub inna odpowiednia odpowiedź, jeśli to jest odpowiednie w Twoim przypadku
        }

        [HttpGet("GetReviewsByBookTitle")]
        [AllowAnonymous]
        public ActionResult<IEnumerable<ReviewDto>> GetReviewsByBookTitle(string bookTitle)
        {
            var reviews = _reviewService.GetReviewsByBookTitle(bookTitle);
            if (reviews != null)
            {
                return Ok(reviews);
            }
            return NotFound("Nie znaleziono opinii dla podanego tytułu książki.");
        }

        [HttpPut("UpdateReviewById")]
        public ActionResult UpdateReview(int reviewId, [FromBody] ReviewDto reviewDto)
        {
            var updatedReview = _reviewService.UpdateReview(reviewId, reviewDto);
            if (updatedReview == null)
            {
                return NotFound("Nie znaleziono recenzji o podanym identyfikatorze.");
            }
            return Ok(updatedReview);
        }

        [HttpDelete("DeleteReviewById")]
        public ActionResult DeleteReview(int reviewId)
        {
            var isDeleted = _reviewService.DeleteReview(reviewId);
            if (!isDeleted)
            {
                return NotFound("Nie znaleziono recenzji o podanym identyfikatorze.");
            }
            return Ok();
        }
    }
}
