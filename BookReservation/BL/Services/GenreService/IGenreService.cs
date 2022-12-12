using System;
using BL.DTOs.BasicDtos;

namespace BL.Services.GenreServ
{
	public interface IGenreService
	{
        void AddGenre(GenreDto genreDto);

        void RemoveGenre(int id);

		Task<IEnumerable<GenreDto>> GetAllGenres();

	}
}

