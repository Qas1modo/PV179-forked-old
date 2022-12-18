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

        public async Task AddBook(BookDto newBook)
        {
            uow.BookRepository.Insert(mapper.Map<Book>(newBook));
            await uow.CommitAsync();
        }

        public async Task<BookBasicInfoDto> GetBook(int bookId)
        {
            Book book = await uow.BookRepository.GetByID(bookId);
            return mapper.Map<BookBasicInfoDto>(book);
        }
    }
}

