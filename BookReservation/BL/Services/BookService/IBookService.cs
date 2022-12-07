using System;
using BL.DTOs;
using BL.DTOs.BasicDtos;

namespace BL.Services.BookServ
{
    public interface IBookService
    {
        int AddBook(BookDto newBook);

        BookDetailInfoDto GetBook(int bookId);

        void UpdateBook(int bookId, BookDto updatedBook);

        void DeleteBook(int bookId);
    }
}

