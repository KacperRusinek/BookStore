using BookStore.Data;
using BookStore.Models;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Services
{
    public interface IReviewService
    {
        public int CreateReview([FromBody] ReviewDto dto);
    }
}
