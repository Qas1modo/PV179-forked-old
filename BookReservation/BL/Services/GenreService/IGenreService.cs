using System;
using BL.DTOs.BasicDtos;
using DAL.Models;

namespace BL.Services.GenreServ
{
    public interface IGenreService
    {
        Task AddGenre(GenreDto genreDto);

        void RemoveGenre(int id);

        Task<Genre> GetOrAddGenre(string genreName);

        Task<IEnumerable<GenreDto>> GetAllGenres();

    }
}

