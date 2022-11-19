using System;
using BL.DTOs.BasicDtos;

namespace BL.Services.AuthorService
{
	public interface IAuthorService
	{
        void AddAuthor(AuthorDto authorDto);

        void RemoveAuthor(int id);
    }
}

