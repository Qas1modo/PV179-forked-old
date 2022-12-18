using System;
using BL.DTOs;
using BL.DTOs.BasicDtos;

namespace BL.Services.BookServ
{
    public interface IBookService
    {
        Task<int> AddBook(BookDto newBook);

        Task<BookBasicInfoDto> GetBook(int bookId);

        Task<bool> UpdateBook(int bookId, BookBasicInfoDto updatedBook);
    }
}

