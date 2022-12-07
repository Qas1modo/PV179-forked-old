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

        public int AddBook(BookDto newBook)
        {
            int id = uow.BookRepository.Insert(mapper.Map<Book>(newBook));
            uow.Commit();
            return id;
        }

        public BookDetailInfoDto GetBook(int bookId)
        {
            Book book = uow.BookRepository.GetByID(bookId);
            return mapper.Map<BookDetailInfoDto>(book);
        }

        public void UpdateBook(int bookId, BookDto updatedBook)
        {
            Book book = uow.BookRepository.GetByID(bookId);
            book = mapper.Map(updatedBook, book);
            uow.BookRepository.Update(book);
            uow.Commit();
        }

        public void DeleteBook(int bookId)
        {
            Book book = uow.BookRepository.GetByID(bookId);
            book.Deleted = true;
            uow.BookRepository.Update(book);
            uow.Commit();
        }
    }
}

