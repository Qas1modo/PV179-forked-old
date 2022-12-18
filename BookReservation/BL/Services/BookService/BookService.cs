using System;
using AutoMapper;
using BL.DTOs.BasicDtos;
using DAL.Models;
using BL.DTOs;
using Infrastructure.UnitOfWork;

namespace BL.Services.BookServ
{
    public class BookService : IBookService
    {
        private readonly IMapper mapper;
        private readonly IUoWBook uow;

        public BookService(IUoWBook uow, IMapper mapper)
        {
            this.uow = uow;
            this.mapper = mapper;
        }

        public async Task<int> AddBook(BookDto newBook)
        {
            int id = uow.BookRepository.Insert(mapper.Map<Book>(newBook));
            await uow.CommitAsync();
            return id;
        }

        public async Task<BookBasicInfoDto> GetBook(int bookId)
        {
            Book book = await uow.BookRepository.GetByID(bookId);
            return mapper.Map<BookBasicInfoDto>(book);
        }

        public async Task<bool> UpdateBook(int bookId, BookBasicInfoDto updatedBook)
        {
            Book book = await uow.BookRepository.GetByID(bookId);
            if (book.Genre.Name != updatedBook.GenreName)
            {
                Genre? newGenre = uow.GenreRepository.GetQueryable()
                .Where(x => x.Name == updatedBook.GenreName)
                .FirstOrDefault();
                if (newGenre == null)
                {
                    return false;
                }
                book.GenreId = newGenre.Id;
            }
            if (book.Author.Name != updatedBook.AuthorName)
            {
                Author? newAuthor = uow.AuthorRepository.GetQueryable()
                .Where(x => x.Name == updatedBook.AuthorName)
                .FirstOrDefault();
                if (newAuthor == null)
                {
                    return false;
                }
                book.AuthorId = newAuthor.Id;
            }
            book = mapper.Map(updatedBook, book);
            uow.BookRepository.Update(book);
            await uow.CommitAsync();
            return true;
        }
    }
}

