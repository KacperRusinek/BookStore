using BookStore.Data;
using BookStore.Models;
using BookStore.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static System.Reflection.Metadata.BlobBuilder;

namespace BookStore.Controllers
{
    [ApiController]
    [Route("api/BookStore")]
    [Authorize]
    public class BooksControllercs : ControllerBase
    {
       
        private readonly ILogger<BookStoreService> _logger;
        private readonly IBookStoreService _bookStoreService;
        public BooksControllercs(IBookStoreService IBS, ILogger<BookStoreService> logger)
        {
            _bookStoreService = IBS;
            _logger = logger;
        }

        [HttpGet("All")]
        [AllowAnonymous]
        public IEnumerable<CreateBookDto> GetAll()
        {
            var books = _bookStoreService.GetAll();
            return books;
        }

        [HttpGet]
        [Route("{id}")]
        [AllowAnonymous]
        public IActionResult GetById([FromRoute] int id)
        { 
            var BookById = _bookStoreService.GetById(id);
            if(BookById == null)
            {
                return NotFound();
            }
            return Ok(BookById);
        }

        [HttpGet("NumberOfPages")]
        [AllowAnonymous]
        public ActionResult<IEnumerable<CreateBook>> GetBookByNumberOfPages([FromQuery] int NumberOfPages)
        {
            var books = _bookStoreService.GetBookByNumberOfPages(NumberOfPages);
            if (books == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(books);
            }
            
        }



        [HttpPost("AddBook")]
        [AllowAnonymous]
        public ActionResult Create([FromBody] CreateBookDto addBook)
        {
            var id = _bookStoreService.Create(addBook);
            return Created($"/api/restaurant/{id}", null);
            
        }

        [HttpPut]
        [Route("{id}")]
        [AllowAnonymous]
        public ActionResult UpdateBook([FromRoute] int id, UpdateBookDto updateBook)
        {
            
            bool isUpdated = _bookStoreService.UpdateBook(id, updateBook);
            if (isUpdated)
            {
                return Ok(updateBook);
            }
            else
            {
                return NotFound();
            }

        }

        [HttpDelete]
        [Route("{id}")]
        [AllowAnonymous]
        public ActionResult DeleteBook([FromRoute] int id)
        {
            bool isDeleted = _bookStoreService.DeleteBook(id);
            if (isDeleted)
            {
                return Ok();
            }
            else
            {
                return NotFound();
            }

        }
        


    }

   

}

