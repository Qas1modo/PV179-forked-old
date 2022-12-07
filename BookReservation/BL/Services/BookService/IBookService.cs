using System;
using BL.DTOs.BasicDtos;

namespace BL.Services.BookServ
{
    public interface IBookService
    {
        int AddBook(BookDto newBook);

        void UpdateBook(int bookId, BookDto updatedBook);

        void DeleteBook(int bookId);
    }
}

