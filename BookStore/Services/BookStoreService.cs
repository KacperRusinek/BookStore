using BookStore.Data;
using BookStore.Models;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Services
{
    public class BookStoreService //logika do obsługiwania zapytań http
    {
        private readonly BookStoreDbContext _dbContext;
        public BookStoreService(BookStoreDbContext bookStoreDbContext)
        {
            _dbContext = bookStoreDbContext;
        }

       
    }
}
