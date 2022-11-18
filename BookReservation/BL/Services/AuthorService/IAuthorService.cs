using System;
using BL.DTOs.BasicDtos;

namespace BL.Services.AuthorService
{
	public interface IAuthorService
	{
        public void AddAuthor(AuthorDto authorDto);

        public void RemoveAuthor(int id);
    }
}

