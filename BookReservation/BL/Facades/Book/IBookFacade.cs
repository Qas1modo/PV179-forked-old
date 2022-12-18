using System;
using BL.DTOs;
using BL.DTOs.BasicDtos;

namespace BL.Facades.BookFac
{
    public interface IBookFacade
    {
        Task AddBook(BookDto bookDto);

        Task<bool> UpdateBook(int bookId, BookChangeDto updatedBook);

        Task DeleteBook(int bookId);
    }
}

