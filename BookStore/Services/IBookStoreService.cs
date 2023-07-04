using BookStore.Data;
using BookStore.Models;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Services
{
    public interface IBookStoreService
    {
          public int Create(CreateBookDto addBook);
          public bool UpdateBook(int id,UpdateBookDto updateBook);
          public bool DeleteBook(int id);
          public IEnumerable<CreateBookDto> GetAll();
          public CreateBookDto GetById(int id);
    }
}