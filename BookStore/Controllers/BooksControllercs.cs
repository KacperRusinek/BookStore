using BookStore.Data;
using BookStore.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Controllers
{
    [ApiController]
    [Route("api/BookStore")]
    public class BooksControllercs : Controller
    {
        private readonly BookStoreDbContext _bookStoreDb;
        public BooksControllercs(BookStoreDbContext bookStoreDb)
        {

            _bookStoreDb = bookStoreDb;
        }
        [HttpGet]
        public async Task<IActionResult> GetBooks()
        {
            return Ok(await _bookStoreDb.Books.ToListAsync());
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetBookById([FromRoute] int id)
        {
            var book = await _bookStoreDb.Books.FindAsync(id);
            if (book == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(book);
            }

        }

        [HttpPost]
        public async Task<IActionResult> AddBook(AddBook addBook)
        {

            var book = new CreateBook()
            {
                Title = addBook.Title,
                FirstNameOfAuthor = addBook.FirstNameOfAuthor,
                LastNameOfAuthor = addBook.LastNameOfAuthor,
                Species = addBook.Species,
                NumberOfPages = addBook.NumberOfPages,
                PublicationDate = addBook.PublicationDate
            };
            await _bookStoreDb.Books.AddAsync(book); //async dlatego bo funkcja jest async rownież a to po to aby inne zapytania mogly sie wykonywac podczas innych
            await _bookStoreDb.SaveChangesAsync();
            return Ok(book);
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> UpdateBook([FromRoute] int id, UpdateBook updateBook)
        {
            var book = await _bookStoreDb.Books.FindAsync(id);
            if (book == null)
            {
                return NotFound();
            } else
            {
                book.Title = updateBook.Title;
                book.FirstNameOfAuthor = updateBook.FirstNameOfAuthor;
                book.LastNameOfAuthor = updateBook.LastNameOfAuthor;
                book.Species = updateBook.Species;
                book.NumberOfPages = updateBook.NumberOfPages;
                book.PublicationDate = updateBook.PublicationDate;

                await _bookStoreDb.SaveChangesAsync();
                return Ok(book);
                    
            }


        }
        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteBook([FromRoute] int id)
        {
            var book = await _bookStoreDb.Books.FindAsync(id);
            if(book == null)
            {
                return NotFound();
            } else
            {
                _bookStoreDb.Remove(book);
                await _bookStoreDb.SaveChangesAsync();
                return Ok();
            }

        }

    }
}
