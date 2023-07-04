﻿using AutoMapper;
using BookStore.Data;
using BookStore.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static System.Reflection.Metadata.BlobBuilder;

namespace BookStore.Services
{
    public class BookStoreService : IBookStoreService
    //logika do obsługiwania zapytań http
    {
     
        private readonly IMapper _mapper;
        private readonly ILogger<BookStoreService> _logger;
        private readonly BookStoreDbContext _dbContext;
        public BookStoreService(BookStoreDbContext bookStoreDbContext, ILogger<BookStoreService> logger, IMapper mapper)
        {
            _dbContext = bookStoreDbContext;
            _logger = logger;
            _mapper = mapper;
        }

        public IEnumerable<CreateBookDto> GetAll()
        {
            var books = _dbContext.Books.ToList();
            var booksDto = _mapper.Map<List<CreateBookDto>>(books);
            return booksDto;
        }

        public CreateBookDto GetById(int id)
        {
            var book = _dbContext.Books.FirstOrDefault(b => b.Id == id);
            var bookDto = _mapper.Map<CreateBookDto>(book);
            return bookDto;
        }
        public int Create(CreateBookDto addBook)
        {
            var book = _mapper.Map<CreateBook>(addBook);
            _dbContext.Books.Add(book);
            _dbContext.SaveChanges();

            return book.Id;
        }

        public bool UpdateBook(int id, UpdateBookDto updateBook)
        {
            var book = _dbContext.Books.Find(id);
            if (book != null)
            {
                // Aktualizacja właściwości książki na podstawie obiektu updateBook
                book.Title = updateBook.Title;
                book.FirstNameOfAuthor = updateBook.FirstNameOfAuthor;
                book.LastNameOfAuthor = updateBook.LastNameOfAuthor;
                book.Species = updateBook.Species;
                book.NumberOfPages = updateBook.NumberOfPages;
                book.PublicationDate = updateBook.PublicationDate;

                _dbContext.SaveChanges();
                return true;
            }
            return false;
        }

        public bool DeleteBook(int id)
        {
            //_logger.LogWarning($"Restaurant with id {id} deleted now"); //jeżeli klient wyśle zapytanie to zostanie to wyświetlone
            var book = _dbContext.Books.Find(id);
            if (book != null)
            {
                _dbContext.Remove(book);
                _dbContext.SaveChanges();
                return true;
            }

            return false;
        }


    }
}
