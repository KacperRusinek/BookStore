using BookStore.Data;
using BookStore.Models;
using BookStore.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Controllers
{
    [ApiController]
    [Route("api/BookStore")]
    //[Authorize]
    public class BooksControllercs : Controller
    {
       
        private readonly ILogger<BookStoreService> _logger;
        private readonly IBookStoreService _bookStoreService;
        public BooksControllercs(IBookStoreService IBS, ILogger<BookStoreService> logger)
        {
            _bookStoreService = IBS;
            _logger = logger;
        }

        [HttpGet]
        //[Authorize] //dodajemy po to, aby tylko użytkownik który ma prawa do przeglądania wszystkiego to robił
        //[Authorize(Roles = "Administrator,Manager")]
        public IEnumerable<CreateBookDto> GetAll()
        {
            var books = _bookStoreService.GetAll();
            return books;
        }

        [HttpGet]
        [Route("{id}")]
        //[AllowAnonymous]
        public IActionResult GetById([FromRoute] int id)
        { 
            var BookById = _bookStoreService.GetById(id);
            return Ok(BookById);
        }

        [HttpPost]
        //[Authorize(Roles = "Administrator,Manager")]
        public ActionResult Create([FromBody] CreateBookDto addBook)
        {
            var id = _bookStoreService.Create(addBook);
            return Created($"/api/restaurant/{id}", null);
            
        }

        [HttpPut]
        [Route("{id}")]
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

