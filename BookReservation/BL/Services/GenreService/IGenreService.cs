using System;
using BL.DTOs.BasicDtos;

namespace BL.Services.GenreService
{
	public interface IGenreService
	{
        void AddGenre(GenreDto genreDto);

        void RemoveGenre(int id);
    }
}

