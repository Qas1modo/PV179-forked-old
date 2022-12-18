using System;
using BL.DTOs.BasicDtos;

namespace BL.Services.GenreServ
{
    public interface IGenreService
    {
        Task<int> AddGenre(GenreDto genreDto);

        void RemoveGenre(int id);

        Task<GenreDto> GetOrAddGenre(string genreName);

        Task<IEnumerable<GenreDto>> GetAllGenres();

    }
}

