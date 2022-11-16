using System;
using BL.DTOs.BasicDtos;

namespace BL.Services.GenreService
{
	public interface IGenreService
	{
        public void AddGenre(GenreDto genreDto);

        public void RemoveGenre(object id);
    }
}

