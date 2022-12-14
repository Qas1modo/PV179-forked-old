using System;
using BL.DTOs;
using BL.DTOs.BasicDtos;

namespace BL.Facades.BookFac
{
    public interface IBookFacade
    {
        Task<int> addBook(AuthorDto authorDto, BookBasicInfoDto bookDto, GenreDto genreDto);
    }
}

